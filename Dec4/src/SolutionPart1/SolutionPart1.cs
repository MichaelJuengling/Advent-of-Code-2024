using System.ComponentModel.Design;
using System.Diagnostics;

namespace Dec4.SolutionPart1;

public class SolutionPart1 (string filePath)
{
    private string[] input;
    private int minRow = 3;
    private int minCol = 3;
    private int maxRow = 0;
    private int maxCol = 0;

    enum Direction
    {
        Top       = 1,
        TopRight  = 2,
        Right     = 3,
        DownRight = 4,
        Down      = 5,
        DownLeft  = 6,
        Left      = 7,
        TopLeft   = 8
    }
    
    public void CalculateSolution()
    {
        input = File.ReadAllLines(filePath);
        
        maxRow = input.Length - 4;      // 140 >> {139,138,137,136}
        maxCol = input[0].Length - 4; 

        int countOfOccurences = 0;
        
        for (int i = 0; i < input.Length; i++) //Row
        {
            for (int j = 0; j < input[0].Length; j++) // Column
            {
                foreach(Direction direction in Enum.GetValues(typeof(Direction))) // Direction
                {
                    if (IsPositionValid(i, j, direction)) 
                    {
                        if (IsXmas(i, j, direction)) countOfOccurences++;
                    }
                }
                
            }
        }
            
        Console.WriteLine($"Number of XMAS: {countOfOccurences}");
    }

    bool IsXmas(int row, int col, Direction direction)
    {
        string stringBuffer = "";

        for (int i = 0; i < 4; i++)
        {        
            stringBuffer += input[row][col];
            switch (direction)
            {
                case Direction.Top:       row--;        break;
                case Direction.TopRight:  row--; col++; break;
                case Direction.Right:            col++; break;
                case Direction.DownRight: row++; col++; break;
                case Direction.Down:      row++;        break;
                case Direction.DownLeft:  row++; col--; break;
                case Direction.Left:             col--; break;
                case Direction.TopLeft:   row--; col--; break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
        return stringBuffer == "XMAS";
    }
    
    
    
    
    
    private bool IsPositionValid(int row , int col, Direction dir)
    {  
        switch (dir)
        {
            case Direction.Top: return row >= minRow;
            case Direction.TopRight: return row >= minRow && col <= maxCol;
            case Direction.Right: return col <= maxCol;
            case Direction.DownRight: return row <= maxRow && col <= maxCol;
            case Direction.Down: return row <= maxRow;
            case Direction.DownLeft: return row <= maxRow && col >= minCol;
            case Direction.Left: return col >= minCol;
            case Direction.TopLeft: return row >= minRow && col >= minCol;
            default: throw new ArgumentOutOfRangeException();
        }
    }

    
}