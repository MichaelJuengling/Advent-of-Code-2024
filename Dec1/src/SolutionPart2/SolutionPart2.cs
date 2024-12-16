namespace Dec1.SolutionPart2;

public class SolutionPart2 (string filePath)
{
    public void CalculateSolution()
    {
        
        string[] input = File.ReadAllLines(filePath);
        List<int> column1 = new List<int>();
        List<int> column2 = new List<int>();
        
        foreach (string line in input)
        {
            string[] parts = line.Split("   ");
            column1.Add(Convert.ToInt32(parts[0]));
            column2.Add(Convert.ToInt32(parts[1]));
        };
    
        int sumOfOccurrences = 0;
        for (int i = 0; i < column1.Count - 1; i++)
        {
            sumOfOccurrences += ((from temp in column2 where temp.Equals(column1[i]) select temp).Count()) * column1[i];
        }
        Console.WriteLine($"Dec1 Part 2 Result: {sumOfOccurrences}");
    }
}