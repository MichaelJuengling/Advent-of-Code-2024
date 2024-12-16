namespace Dec2.SolutionPart2;

public class SolutionPart2 (string filePath)
{
    public void CalculateSolution()
    {
        
        var input = File.ReadAllLines(filePath);
        int numberOfValidReports = 0;
        
        foreach (var line in input)
        {
            var numbers = line.Split(" ").Select(numbers => Convert.ToInt32(numbers));
            
            if (IsReportValid(numbers)) numberOfValidReports++;
            else
            {
                for (int i = 0; i < numbers.Count(); i++)
                {
                    List<int> tempNumbers = numbers.ToList();
                    tempNumbers.RemoveAt(i);
                    if (IsReportValid(tempNumbers))
                    {
                        numberOfValidReports++;
                        break;
                    }
                }
            }
         
        }
        
        Console.WriteLine($"Dec2 Part 1 Result: {numberOfValidReports}");
    }
    private bool IsReportValid(IEnumerable<int> numbers)
    {
        var enumerable = numbers.ToList();
        int errors = 0;
        int increasing = 0;
        int decreasing = 0;
        for (int i = 0; i < enumerable.Count()-1; i++)
        {
            //all increasing or all decreasing
            if (enumerable[i] > enumerable[i + 1]) ++increasing;
            else if (enumerable[i] < enumerable[i + 1]) ++decreasing;
                
            //adjacent levels differ by 1 to 3
            int diff = Math.Abs(enumerable[i] - enumerable[i + 1]);
            if (diff < 1 || diff > 3) errors++;
        }
        if (errors == 0 && (increasing > 0 ^ decreasing > 0)) return true;
        else return false;
    }
}