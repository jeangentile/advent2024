using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace day04;

class Program
{

    static int gridWidth = 0;
    static int gridLength = 0;
    static string[] gridLines;
    static List<string> allLines = new List<string>();
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Day 04!");
 
        var gridContent = File.ReadAllText("c:\\dev\\advent2024\\advent2024\\day04\\input.txt");
        gridLines = gridContent.Split(Environment.NewLine);
        gridWidth = gridLines[0].Length;
        gridLength = gridLines.Length;

        Console.WriteLine($"Grid Width: {gridWidth}");
        Console.WriteLine($"Grid Length: {gridLength}");

        ScanGrid();
    }

    static void ScanGrid()
    {
        //lines
        for(var yPos = 0; yPos < gridLength; yPos++)
        {
            var line = gridLines[yPos];
            Console.WriteLine($"Line [{yPos}]: {line}");
            allLines.Add(line);
        }

        //columns
        for(var yPos = 0; yPos < gridLength; yPos++)
        {
            var column = "";
            for(var xPos = 0; xPos < gridWidth; xPos++)
            {
                column += gridLines[xPos].Substring(yPos, 1);
            }
            Console.WriteLine($"Column [{yPos}]: {column}");
            allLines.Add(column);
        }

        //diagonals down
        for (var lineOffset = 0; lineOffset < gridLength; lineOffset++)
        {
            Console.WriteLine($"Diagonal starting row DOWN: {lineOffset}");

            for(var lineCounter = lineOffset; lineCounter < gridLength; lineCounter++)
            {
                var y = lineCounter;
                var diagonal = "";
                for(var x = 0; x < gridWidth - lineCounter; x++)
                {
                    diagonal += gridLines[x].Substring(y,1);

                    Console.Write($"({x},{y})");
                    //Console.Write($"{gridLines[x].Substring(y,1)} ");
                    y++;
                }

                Console.WriteLine($"Diagonal DOWN [{lineCounter}]: {diagonal}");
                allLines.Add(diagonal);
            }
        }

        //diagonals up
        for (var startingRow = gridLength - 1; startingRow > 0; startingRow--)
        {
            Console.WriteLine($"Diagonal starting row UP: {startingRow}");

            for(var lineRepeat = 0; lineRepeat < startingRow + 1; lineRepeat++)
            {
                var y = startingRow;
                var diagonal = "";
                for(var x = lineRepeat; x < gridWidth - (gridLength - startingRow - 1); x++)
                {
                        Console.Write($"({x},{y})");
                        diagonal += gridLines[y].Substring(x,1);
                        y--;
                }
                Console.WriteLine($"Diagonal UP [{startingRow}]: {diagonal}");
                allLines.Add(diagonal);
            }
        }

        var totalMatches = 0;
        totalMatches += FindMatches("XMAS");
        totalMatches += FindMatches("SAMX");

        Console.WriteLine($"totalMatches: {totalMatches}");

    }

    static int FindMatches(string match)
    {
        var matchCounter = 0;
        var matchPattern = $"{match}";

        foreach(var line in allLines)
        {
            var matches = Regex.Matches(line, matchPattern);
            if (matches.Count > 0)
            {
                matchCounter += matches.Count;
            }
        }

        return matchCounter;
    }
}
