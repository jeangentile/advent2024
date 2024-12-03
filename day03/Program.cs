namespace day03;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Day 03!");
 
        var reader = System.IO.File.ReadAllText("c:\\dev\\advent2024\\advent2024\\day03\\input.txt");
        var portions = reader.Split("mul(", StringSplitOptions.TrimEntries);
        long totalResult = 0;
        var enabled = true;

        foreach(var portion in portions)
        {
            long portionResult = -1;
            Console.WriteLine(portion);
            if (portion.IndexOf(")") > -1)
            {
                var trimmed = portion.Substring(0, portion.IndexOf(")", StringComparison.CurrentCultureIgnoreCase));
                Console.WriteLine(trimmed);

                var splitTrim = trimmed.Split(",");
                if (splitTrim.Length == 2)
                {
                    if (int.TryParse(splitTrim[0], out int leftInt))
                    {
                        if (int.TryParse(splitTrim[1], out int rightInt))
                        {
                            if (enabled)
                            {
                                portionResult = leftInt * rightInt;
                                totalResult += portionResult;
                            }
                        }
                    }
                }

                if(portion.Contains("don't()", StringComparison.CurrentCultureIgnoreCase))
                {
                    enabled = false;
                }
                if(portion.Contains("do()", StringComparison.CurrentCultureIgnoreCase))
                {
                    enabled = true;
                }
            }
            Console.WriteLine();
        }

        Console.WriteLine(totalResult);
    }
}
