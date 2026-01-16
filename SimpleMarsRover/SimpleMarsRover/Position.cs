namespace SimpleMarsRover;

public class Position
{
    private const char North = 'N';
    private const char East = 'E';
    private const char South = 'S';
    private const char West = 'W';
    
    private const char Left = 'L';
    private const char Right = 'R';
    private const char Move = 'M';
    
    private const int MinimumIndex = 0;
    private const int MaximumIndex = 9;

    public int X { get; private set; }

    public int Y { get; private set; } 

    public char Direction { get; private set; }

    public Position(int x, int y, char direction)
    {
        X = x;
        Y = y;
        Direction = direction;
    }

    public Position()
    {
        X = 0;
        Y = 0;
        Direction = North;
    }

    public void Execute(char command)
    {
        switch (command)
        {
            case Left:
                TurnLeft();
                break;
            case Right:
                TurnRight();
                break;
            case Move:
                MoveForward();
                break;
        }
    }

    private void TurnLeft()
    {
        Direction = Direction switch
        {
            North => West,
            West => South,
            South => East,
            East => North,
            _ => Direction
        };
    }

    private void TurnRight()
    {
        Direction = Direction switch
        {
            North => East,
            East => South,
            South => West,
            West => North,
            _ => Direction
        };
    }

    private void MoveForward()
    {
        switch (Direction)
        {
            case North:
                Y = IncrementPositionIndex(Y);
                break;
            case East:
                X = IncrementPositionIndex(X);
                break;
            case South:
                Y = DecrementPositionIndex(Y);
                break;
            case West:
                X = DecrementPositionIndex(X);
                break;
        }
    }
    
    public override string ToString()
    {
        return $"{X}:{Y}:{Direction}";
    }

    private static int IncrementPositionIndex(int index)
    {
        index++;
        
        if (index > MaximumIndex)
        {
            index = MinimumIndex;
        }

        return index;
    }
    
    private static int DecrementPositionIndex(int index)
    {
        index--;
        
        if (index < MinimumIndex)
        {
            index = MaximumIndex;
        }

        return index;
    }
}