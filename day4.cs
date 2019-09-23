using System;
using System.Collections.Generic;
using System.Linq;
public class DayFour
{

    public List<string> lines = System.IO.File.ReadAllLines(@"./day4.txt").ToList();

    public void runStarOne()
    {
        // var lines = new List<string>(){
        //     "[1518-11-01 00:00] Guard #10 begins shift",
        //     "[1518-11-01 00:05] falls asleep",
        //     "[1518-11-01 00:25] wakes up",
        //     "[1518-11-01 00:30] falls asleep",
        //     "[1518-11-03 00:24] falls asleep",
        //     "[1518-11-03 00:29] wakes up",
        //     "[1518-11-04 00:02] Guard #99 begins shift",
        //     "[1518-11-04 00:36] falls asleep",
        //     "[1518-11-05 00:03] Guard #99 begins shift",
        //     "[1518-11-05 00:45] falls asleep",
        //     "[1518-11-05 00:55] wakes up",
        //     "[1518-11-01 00:55] wakes up",
        //     "[1518-11-01 23:58] Guard #99 begins shift",
        //     "[1518-11-02 00:40] falls asleep",
        //     "[1518-11-02 00:50] wakes up",
        //     "[1518-11-03 00:05] Guard #10 begins shift",
        //     "[1518-11-04 00:46] wakes up",
        // };

        var sortedLines = lines.OrderBy(line => line.Split("[")[1].Split("]")[0]).ToList();
        var guardSleepTimer = new Dictionary<string, List<int>>();

        string guardOnShift = "-23043243";

        int asleepMinute = -1;

        foreach (var line in sortedLines)
        {
            System.Console.WriteLine($"{line}");
            int currentMinute = Int32.Parse(Utils.ExtractBetween(line, ":", "]"));
            System.Console.WriteLine($"minute {currentMinute}");

            if(line.Contains("Guard")){
                guardOnShift = Utils.ExtractBetween(line, "#", " begins");
                System.Console.WriteLine($"Guard on shift now '{guardOnShift}'");
            }
            
            if(line.Contains("asleep")){
                asleepMinute = currentMinute;
                System.Console.WriteLine("Guard is now asleep");
            }

            if(line.Contains("wakes")){
                if (!guardSleepTimer.ContainsKey(guardOnShift)){
                    guardSleepTimer.Add(guardOnShift, new List<int>());
                }

                var amountOfMinutes = currentMinute - asleepMinute;
                var minutesRange = Enumerable.Range(asleepMinute, amountOfMinutes);
                var asString = String.Join(",", minutesRange);

                System.Console.WriteLine(amountOfMinutes);

                guardSleepTimer[guardOnShift].AddRange(minutesRange);

                System.Console.WriteLine($"Guard is now awake, slept for {amountOfMinutes}, Adding minutes {asString}");
                asleepMinute = -1;

            }            
        }

        System.Console.WriteLine("Summary:");

        // TODO find the sleepiest guard based on SleepKV.Value.Count()
        foreach (var sleepKV in guardSleepTimer){
            System.Console.WriteLine($"Guard {sleepKV.Key} :  {sleepKV.Value.Count()}");

            var value = sleepKV.Value.GroupBy(t => t)
                .OrderByDescending(grp => grp.Count())
                .First().Key;
            
            
            // Most minutes..?
            System.Console.WriteLine($"Guard spent the minute {value} sleeping most ");

            var totalValue = value * Int32.Parse(sleepKV.Key);
            System.Console.WriteLine($"Total value {totalValue}");

        }

    }

    public void runStarTwo()
    {

    }

}
