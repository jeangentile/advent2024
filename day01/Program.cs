using System.Collections.Immutable;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;

namespace day01;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        //readall
        var reader = System.IO.File.ReadAllText("c:\\dev\\advent2024\\\\advent2024\\day01\\input.txt");

        //split into two arrays sideA and sideB
        var sideA = new List<int>();
        var sideB = new List<int>();
        foreach(var line in reader.Split(Environment.NewLine))
        {
            var pairs = line.Split("   ");
            sideA.Add(int.Parse(pairs[0]));
            sideB.Add(int.Parse(pairs[1]));
        }

        //sort each array ascending
        sideA.Sort();
        sideB.Sort();
        Console.WriteLine(sideA.Count());

        //accumulate sum of distances
        var sumDistances = 0;

        //compare each pair, calculate distance between, and add to sum
        for(var counter = 0; counter < sideA.Count(); counter++)
        {
            var distance = Math.Abs(sideB[counter] - sideA[counter]);
            sumDistances += distance;
        }

        //answer1
        Console.WriteLine(sumDistances);

        //accumulate similarity score
        long similarityScore = 0;


        //calculate similarity
        for(var counter = 0; counter < sideA.Count(); counter++)
        {
            var foundRight = sideB.Where(g => g == sideA[counter]);
            var score = sideA[counter] * foundRight.Count();
            similarityScore += score;
        }

        //answer2
        Console.WriteLine(similarityScore);


    }
}
