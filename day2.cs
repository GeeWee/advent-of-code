using System;
using System.Collections.Generic;
using System.Linq;
public class DayTwo
{

    public List<string> lines = System.IO.File.ReadAllLines(@"./day2.txt").ToList();

    public void runStarOne()
    {
        // var lines = new List<string>() { "abcdef", "bababc", "abbcde", "abcccd", "aabcdd", "abcdee", "ababab" };

        var sum2 = 0;
        var sum3 = 0;
        foreach (var line in lines)
        {
            System.Console.WriteLine($"Checking {line}");
            var count2Exists = line.GroupBy(c => c)
            .Where(grouping =>
            {
                return grouping.Count() == 2;
            }
            ).Any();

            if (count2Exists)
            {
                sum2 += 1;
            }

            System.Console.WriteLine($"count2Exists: {count2Exists}");

            var count3Exists = line.GroupBy(c => c)
            .Where(grouping =>
            {
                return grouping.Count() == 3;
            }
            ).Any();

            if (count3Exists)
            {
                sum3 += 1;
            }

            System.Console.WriteLine($"count3Exists: {count3Exists}");
        }
        System.Console.WriteLine($"2: {sum2}, 3: {sum3}, multiplied: {sum2 * sum3}");
    }

    public void runStarTwo()
    {
        // var lines = new List<string>() { "abcde", "fghij", "klmno", "pqrst", "fguij", "axcye", "wvxyz"};

        // This could probably be solved more elegantly by a Hamming distance check, but let's do it by hand
        for (int index = 0; index < lines.Count(); index++)
        {
            var firstId = lines[index];

            for (int index2 = index + 1; index2 < lines.Count(); index2++)
            {
                // Nested for loop to check all later ids

                var secondId = lines[index2];

                var mergedList = firstId.Zip(secondId, (firstChar, secondChar) =>
                {
                    return new
                    {
                        firstChar = firstChar,
                        secondChar = secondChar,
                    };
                });

                var listWithoutDuplicates = mergedList.Where((pair) =>
                {
                    return pair.firstChar == pair.secondChar;
                })
                .Select(pair => pair.firstChar);
                
                var asString = String.Join("", listWithoutDuplicates);
                if (asString.Length == firstId.Length - 1)
                {
                    System.Console.WriteLine($"Found it: {asString}");
                }
            }
        }

    }
}
