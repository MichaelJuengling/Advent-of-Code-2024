using System.Text.RegularExpressions;

namespace Dec3.SolutionPart2;


public class SolutionPart2 (string filePath)
{
    public void CalculateSolution()
    {
        var input = File.ReadAllText(filePath).Replace(Environment.NewLine, "");
        var cleanedInput = Regex.Replace(input, @"don't\(\).*?do\(\)", "");
        var allMatches = Regex.Matches(cleanedInput, @"mul\((\d{1,3}),(\d{1,3})\)");
        
        int sumOfProducts = 0;
        foreach (Match match in allMatches)
        {
            sumOfProducts += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
        }
        
        Console.WriteLine($"Dec3 Part 2 Result: {sumOfProducts}");
    }
}
//Commit me
