// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var j = new Day6Part1();
var result = await j.SolveAsync(new StreamReader("c:\\dev\\advent2024\\advent2024\\day06\\input-test.txt"));
Console.WriteLine(result);

public partial class Day6Part1
{
    public async Task<string> SolveAsync(StreamReader inputReader)
    {
        await Task.CompletedTask;

        return "HI";
    }
}