namespace Dec1.SolutionPart1;

public class SolutionPart1 (string filePath)
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
        
        column1.Sort();
        column2.Sort();
        
        int sumOfDistances = 0;
        for (int i = 0; i < column1.Count; i++)
        {
            sumOfDistances += Math.Abs(column1[i] - column2[i]);
        }
        Console.WriteLine($"Dec1 Part 1 Result: {sumOfDistances}");
    }
}