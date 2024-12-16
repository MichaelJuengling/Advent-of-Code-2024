using System.Text.RegularExpressions;

namespace Dec3.SolutionPart1;

public class SolutionPart1 (string filePath)
{
    public void CalculateSolution()
    {
        var input = File.ReadAllText(filePath);
        var allMatches = Regex.Matches(input, @"mul\((\d{1,3}),(\d{1,3})\)");
        
        int sumOfProducts = 0;
        foreach (Match match in allMatches)
        {
            sumOfProducts += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
        }
        
        Console.WriteLine($"Dec3 Part 1 Result: {sumOfProducts}");
    }
}