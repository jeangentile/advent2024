// See https://aka.ms/new-console-template for more information
using System.Collections;
using Microsoft.VisualBasic;


Console.WriteLine("Hello, World!");

var rulestxt = File.ReadAllText("c:\\dev\\advent2024\\advent2024\\day05\\rules.txt");
var input = File.ReadAllText("c:\\dev\\advent2024\\advent2024\\day05\\input.txt");

var rules = new Dictionary<int, RuleMap>();
foreach(var ruleLine in rulestxt.Split(Environment.NewLine))
{
    var ruleLineSplit = ruleLine.Split("|");

    var pageLeft = int.Parse(ruleLineSplit[0]);
    var pageRight = int.Parse(ruleLineSplit[1]);

    if (!rules.TryGetValue(pageLeft, out var ruleMapLeft))
    {
        ruleMapLeft = new RuleMap(pageLeft);
        rules.Add(pageLeft, ruleMapLeft);
    }
    ruleMapLeft.PagesAfter.Add(pageRight);
    rules[pageLeft] = ruleMapLeft;

    if (!rules.TryGetValue(pageRight, out var ruleMapRight))
    {
        ruleMapRight = new RuleMap(pageRight);
        rules.Add(pageRight, ruleMapRight);
    }
    ruleMapRight.PagesBefore.Add(pageLeft);
    rules[pageRight] = ruleMapRight;

}

var middlePages = 0;

foreach(var inputLine in input.Split(Environment.NewLine))
{
    var lineIsValid = EvaluateLine(inputLine);
    var inputLineSplit = inputLine.Split(",");

    if (lineIsValid)
    {
        var middlePage = int.Parse(inputLineSplit[inputLineSplit.Length /2]);
        middlePages += middlePage;
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine($"##Fixing broken row {inputLine}");
        var newLine = new List<int>();

        for(var splitPosition = 0; splitPosition < inputLineSplit.Length; splitPosition++)
        {
            var page = int.Parse(inputLineSplit[splitPosition]);
            Console.WriteLine($"  >Page: {page} ");
            if (!rules.TryGetValue(page, out var pageRules))
            {
                newLine.Add(page);
            }
            else
            {
                
            }
        }
    }

}

bool EvaluateLine(string inputLine)
{
    Console.WriteLine($"Evaluating {inputLine}");
    
    var inputLineSplit = inputLine.Split(",");


    for(var splitPosition = 0; splitPosition < inputLineSplit.Length; splitPosition++)
    {
        var page = int.Parse(inputLineSplit[splitPosition]);
        Console.WriteLine($"  >Page: {page} ");
        
        //find matching rules for this page        
        if (rules.TryGetValue(page, out var pageRules))
        {
            //check all pages after this page
            for(var positionAfter = splitPosition + 1; positionAfter < inputLineSplit.Length; positionAfter++)
            {
                var pageAfter = int.Parse(inputLineSplit[positionAfter]);
                Console.Write($"         Page After {pageAfter} ");

                var canBeAfter = pageRules.PagesAfter.Contains(pageAfter);
                Console.Write($"{canBeAfter} ");

                if (!canBeAfter)
                {
                    return false;
                }

                Console.WriteLine();
            }

            //check all pages before this page
            for(var positionBefore = splitPosition - 1; positionBefore > -1; positionBefore--)
            {
                var pageBefore = int.Parse(inputLineSplit[positionBefore]);
                Console.Write($"         Page Before {pageBefore} ");

                var canBeBefore = pageRules.PagesBefore.Contains(pageBefore);
                Console.Write($"{canBeBefore} ");

                if (!canBeBefore)
                {
                    return false;
                }

                Console.WriteLine();
            }

        }
    }
    Console.WriteLine();

    return true;
}


Console.WriteLine($"Valid Middle Pages: {middlePages}");

public class RuleMap
{
    public int Page;
    public List<int> PagesBefore = new List<int>();
    public List<int> PagesAfter = new List<int>();

    public RuleMap(int page)
    {
        Page = page;
    }
}
