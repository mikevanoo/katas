using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GildedRose.Console;
using GildedRose.Console.UpdateStrategies;
using VerifyXunit;
using Xunit;

namespace GildedRose.Tests
{
    [UsesVerify]
    public class GoldenMasterTests
    {
        private const int FixedSeed = 100;
        private const int NumberOfItems = 2000;
        private const int Minimum = 0;
        private const int Maximum = 50;
        
        private readonly string[] _itemNames = {
            "+5 Dexterity Vest",
            "Aged Brie",
            "Elixir of the Mongoose",
            "Sulfuras, Hand of Ragnaros",
            "Backstage passes to a TAFKAL80ETC concert",
            "Conjured Mana Cake"
        };

        // Fixed seed ensures reproducible test data: generates diverse items deterministically for golden master verification
        private readonly Random _random = new Random(FixedSeed);
        private readonly Console.GildedRose _gildedRose = new Console.GildedRose(new ItemUpdateStrategyFactory());

        [Fact]
        public Task Should_Generate_Update_Quality_Output()
        {
            List<Item> items = GenerateTestItems(NumberOfItems);

            _gildedRose.UpdateQuality(items);

            return Verifier.Verify(GetStringRepresentationFor(items));
        }

        private List<Item> GenerateTestItems(int numberOfItems) {
            var items = new List<Item>();
            for (var count = 0; count < numberOfItems; count++) {
                items.Add(new Item { Name = ItemName(), SellIn = SellIn(), Quality = Quality() });
            }
            return items;
        }

        private string ItemName() {
            return _itemNames[0 + _random.Next(_itemNames.Length)];
        }

        private int SellIn() {
            return NumberBetween(Minimum, Maximum);
        }

        private int Quality() {
            return NumberBetween(Minimum, Maximum);
        }

        private int NumberBetween(int minimum, int maximum) {
            return minimum + _random.Next(maximum);
        }

        private string GetStringRepresentationFor(List<Item> items) {
            var builder = new StringBuilder();
            foreach (var item in items)
            {
                builder.AppendLine($"Item [name={item.Name}, sellIn={item.SellIn}, quality={item.Quality}]");
            }
            return builder.ToString();
        }
    }
}