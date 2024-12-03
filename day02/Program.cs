namespace day02;

class Program
{
    const int minDiff = 1;
    const int maxDiff = 3;

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
 
        var reader = System.IO.File.ReadAllText("c:\\dev\\advent2024\\\\advent2024\\day02\\input.txt");

        var safeCount = 0;

        foreach(var line in reader.Split(Environment.NewLine))
        {
            var report = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            if (IsSafe(report))
            {
                safeCount++;
            }
            else
            {
                for (int i = 0; i < report.Count; i++)
                {
                    var reportCopy = report.ToList();
                    reportCopy.RemoveAt(i);
                    if (IsSafe(reportCopy))
                    {
                        safeCount++;
                        break;
                    }
                }
            }
        }

        Console.WriteLine(safeCount);
    }

    static bool IsSafe(List<int> report)
    {
        if (report.Count < 2)
        {
            return true;
        }

        var firstDiff = report[1] - report[0];

        if (firstDiff == 0 || Math.Abs(firstDiff) > 3)
        {
            return false;
        }

        var expectedSgn = firstDiff / Math.Abs(firstDiff);

        for (int i = 1; i < report.Count - 1; i++)
        {
            var diff = report[i + 1] - report[i];
            if (diff == 0 || Math.Abs(diff) > 3)
            {
                return false;
            }

            var sgn = diff / Math.Abs(diff);
            if (sgn != expectedSgn)
            {
                return false;
            }
        }

        return true;
    }
}