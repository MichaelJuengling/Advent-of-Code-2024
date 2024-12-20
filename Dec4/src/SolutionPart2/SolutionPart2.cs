namespace Dec4.SolutionPart2;

public class SolutionPart2 (string filePath)
{
    private string[] input;
    private int numberOfOccurrences;
    
    public void CalculateSolution()
    {
        input = File.ReadAllLines(filePath);
        
        //loop over valid indices
        for (int i = 1; i < input.Length-1; i++)
        {
            for (int j = 1; j < input.Length - 1; j++)
            {
                if(IsPatternMatching(i,j)) numberOfOccurrences++;
            }
        }
        Console.WriteLine($"Number of 'MAS': {numberOfOccurrences}");
    }


    private bool IsPatternMatching(int row, int col)
    {
        //get buffer
        string[] stringBuffer = new string[3];
        stringBuffer[0] = input[row-1][col-1] + " " + input[row-1][col+1];
        stringBuffer[1] = (" " + input[row][col] + " ").ToString();
        stringBuffer[2] = (input[row+1][col-1] + " " + input[row+1][col+1]).ToString();
        
        //check against 4 patterns
        if (stringBuffer[0] == "M M" && stringBuffer[1] == " A " && stringBuffer[2] == "S S") return true; // Top Bottom
        if (stringBuffer[0] == "M S" && stringBuffer[1] == " A " && stringBuffer[2] == "M S") return true; // Left Right
        if (stringBuffer[0] == "S S" && stringBuffer[1] == " A " && stringBuffer[2] == "M M") return true; // Bottom Top 
        if (stringBuffer[0] == "S M" && stringBuffer[1] == " A " && stringBuffer[2] == "S M") return true; // Right Left
        return false;

    }

        
        

}