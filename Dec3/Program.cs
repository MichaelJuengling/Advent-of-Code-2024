using Dec3.SolutionPart1;
using Dec3.SolutionPart2;

class Program
{
    public static void Main(string[] args)
    {
        var solutionPart1 = new SolutionPart1("data/Input.txt");
        solutionPart1.CalculateSolution();
        var solutionPart2 = new SolutionPart2("data/Input.txt");
        solutionPart2.CalculateSolution();
    }
}