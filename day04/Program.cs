using System.Security.Cryptography.X509Certificates;
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

        Part2();
    }


    static void Part2()
    {
        var matchCounter = 0;
        for(var row = 0; row < gridLength - 2; row++)
        {
            for(var col = 0; col < gridWidth - 2; col++)
            {
                var stringPart1 = gridLines[row].Substring(col,3);
                var stringPart2 = gridLines[row+1].Substring(col,3);
                var stringPart3 = gridLines[row+2].Substring(col,3);
                if(Regex.IsMatch(stringPart1, "M.S"))
                {
                    if(Regex.IsMatch(stringPart2, ".A."))
                    {
                        if(Regex.IsMatch(stringPart3, "M.S"))
                        {
                            Console.WriteLine($"MATCH! {stringPart1}, {stringPart2}, {stringPart3}");
                            matchCounter++;
                        }
                    }
                }
                if(Regex.IsMatch(stringPart1, "S.M"))
                {
                    if(Regex.IsMatch(stringPart2, ".A."))
                    {
                        if(Regex.IsMatch(stringPart3, "S.M"))
                        {
                            Console.WriteLine($"MATCH! {stringPart1}, {stringPart2}, {stringPart3}");
                            matchCounter++;
                        }
                    }
                }
                if(Regex.IsMatch(stringPart1, "S.S"))
                {
                    if(Regex.IsMatch(stringPart2, ".A."))
                    {
                        if(Regex.IsMatch(stringPart3, "M.M"))
                        {
                            Console.WriteLine($"MATCH! {stringPart1}, {stringPart2}, {stringPart3}");
                            matchCounter++;
                        }
                    }
                }
                if(Regex.IsMatch(stringPart1, "M.M"))
                {
                    if(Regex.IsMatch(stringPart2, ".A."))
                    {
                        if(Regex.IsMatch(stringPart3, "S.S"))
                        {
                            Console.WriteLine($"MATCH! {stringPart1}, {stringPart2}, {stringPart3}");
                            matchCounter++;
                        }
                    }
                }
            }
        }


        Console.WriteLine($"Matches {matchCounter}");
    }

    static void Part1()
    {
        //lines
        for(var yPos = 0; yPos < gridLength; yPos++)
        {
            var line = gridLines[yPos];
            Console.WriteLine($"Line [{yPos}]: {line}");
            allLines.Add(line);
        }
        Console.WriteLine();
        Console.WriteLine();

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
        Console.WriteLine();
        Console.WriteLine();

        //diagonals down
        for (var startingRowDown = 0; startingRowDown < gridLength; startingRowDown++)
        {
            Console.WriteLine($"Diagonal starting row DOWN: {startingRowDown}");

            var y = startingRowDown;
            var diagonal = "";
            for(var x = 0; x < gridWidth - startingRowDown; x++)
            {
                diagonal += gridLines[y].Substring(x,1);
                Console.Write($"(row{y},col{x})");
                y++;
            }
            Console.WriteLine($"Diagonal DOWN row [{y}]: {diagonal}");
            allLines.Add(diagonal);
        }
        Console.WriteLine();
        Console.WriteLine();

        //diagonals across
        for (var startingColAcross = 1; startingColAcross < gridWidth; startingColAcross++)
        {
            Console.WriteLine($"Diagonal starting columns ACROSS: {startingColAcross}");

            var y = 0;
            var diagonal = "";
            for(var x = startingColAcross; x < gridWidth; x++)
            {
                diagonal += gridLines[y].Substring(x,1);
                Console.Write($"(row{y},col{x})");
                y++;
            }
            Console.WriteLine($"Diagonal ACROSS column [{startingColAcross}]: {diagonal}");
            allLines.Add(diagonal);
        }
        Console.WriteLine();
        Console.WriteLine();

        //diagonals up
        for (var startingRowUp = gridLength - 1; startingRowUp > -1; startingRowUp--)
        {
            Console.WriteLine($"Diagonal starting row UP: {startingRowUp}");

            var y = startingRowUp;
            var diagonal = "";
            for(var x = 0; x < gridWidth - (gridLength - 1 - startingRowUp); x++)
            {
                diagonal += gridLines[y].Substring(x,1);
                Console.Write($"(row{y},col{x})");
                y--;
            }
            Console.WriteLine($"Diagonal UP row [{y}]: {diagonal}");
            allLines.Add(diagonal);
        }
        Console.WriteLine();
        Console.WriteLine();
        
        //diagonals upacross
        for (var startingColUpAcross = 1; startingColUpAcross < gridWidth; startingColUpAcross++)
        {
            Console.WriteLine($"Diagonal starting columns UPACROSS: {startingColUpAcross}");

            var y = gridLength - 1;
            var diagonal = "";
            for(var x = startingColUpAcross; x < gridWidth; x++)
            {
                diagonal += gridLines[y].Substring(x,1);
                Console.Write($"(row{y},col{x})");
                y--;
            }
            Console.WriteLine($"Diagonal UPACROSS column [{startingColUpAcross}]: {diagonal}");
            allLines.Add(diagonal);
        }
        Console.WriteLine();
        Console.WriteLine();       


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
