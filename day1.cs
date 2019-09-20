using System;
using System.Collections.Generic;
using System.Linq;
public class DayOne
{

    public void runStarOne()
    {

        var lines = System.IO.File.ReadAllLines(@"./day1.txt");

        var result = lines.
            Select(i => Int32.Parse(i))
            .Sum();

        System.Console.WriteLine(result);

    }

    public void runStarTwo()
    {
        System.Console.WriteLine("Hello from day one!");

        var lines = System.IO.File.ReadAllLines(@"./day1.txt").Select(i => Int32.Parse(i));

        // List all previous found seeds - could be an array, but it's easier to check if a key already exists in a dict
        var previousSeeds = new Dictionary<int, bool>();
        var sum = 0;
        foreach (var line in this.GetInfiniteSeries(lines))
        {
            sum += line;
            System.Console.WriteLine($"sum {sum}, line {line}");
            if (previousSeeds.ContainsKey(sum))
            {
                System.Console.WriteLine($"found it! {sum}");
                break;
            }
            previousSeeds[sum] = true;
        }

    }

    // Yield infinite list, from https://stackoverflow.com/questions/3575682/linq-infinite-list-from-given-finite-list
    IEnumerable<int> GetInfiniteSeries(IEnumerable<int> items)
    {
        while (true)
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }
    }
}
