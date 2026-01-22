using System.Collections.Generic;
using GildedRose.Console.UpdateStrategies;

namespace GildedRose.Console
{
    class Program
    {
        IList<Item> Items; // can't change this property
        
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 10,
                        Quality = 49
                    },
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 5,
                        Quality = 49
                    },
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                }

            };

            const int days = 30;
            for (var i = 0; i <= days; i++)
            {
                System.Console.WriteLine("-------- day " + i + " --------");
                System.Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < app.Items.Count; j++)
                {
                    System.Console.WriteLine(app.Items[j].Name + ", " + app.Items[j].SellIn + ", " + app.Items[j].Quality);
                }
                System.Console.WriteLine("");
                app.UpdateQuality();
            }

            System.Console.ReadKey();
        }

        private void UpdateQuality()
        {
            var gildedRose = new GildedRose(new ItemUpdateStrategyFactory());
            gildedRose.UpdateQuality(Items);
        }
    }
}
