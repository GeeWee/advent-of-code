using System;
using System.Collections.Generic;
using System.Linq;
public class DayThree
{

    public List<string> lines = System.IO.File.ReadAllLines(@"./day3.txt").ToList();

    public void runStarOne()
    {
        // var lines = new List<string>() { "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2" };
        var claimsSet = new HashSet<string>();
        var contestedClaimsSet = new HashSet<string>();
        // Make a coordinate system that starts from 0,0 in the top left corner
        foreach (var line in lines)
        {
            var distanceFromLeft = Int32.Parse(line.Split("@ ")[1].Split(",")[0]);
            var distanceFromTop = Int32.Parse(line.Split(",")[1].Split(":")[0]);
            var width = Int32.Parse(line.Split(" ").Last().Split("x")[0]);
            var height = Int32.Parse(line.Split(" ").Last().Split("x")[1]);
            // System.Console.WriteLine($"distanceFromLeft: {distanceFromLeft}");
            // System.Console.WriteLine($"distanceFromTop: {distanceFromTop}");
            // System.Console.WriteLine($"width: {width}");
            // System.Console.WriteLine($"length: {height}");

            // We need to calculate the points for this thing.

            // For each point on the x-axis, calculate that point, and all corresponding points on the y axis
            foreach (var xPoint in Enumerable.Range(distanceFromLeft, width))
            {
                foreach (var yPoint in Enumerable.Range(distanceFromTop, height))
                {

                    var pointString = $"{xPoint}, {yPoint}";
                    System.Console.WriteLine($"Point taken up: {pointString} ");

                    // Check whether or not the claim is in the claimsSet
                    if (claimsSet.Contains(pointString))
                    {
                        contestedClaimsSet.Add(pointString);
                    }
                    else
                    {
                        claimsSet.Add(pointString);
                    }

                }
            }


        }

        System.Console.WriteLine("Claimsset");
        claimsSet.ToList().ForEach(System.Console.WriteLine);
        System.Console.WriteLine("contestedClaimsSet");
        contestedClaimsSet.ToList().ForEach(System.Console.WriteLine);
        System.Console.WriteLine($"Contested claims: {contestedClaimsSet.Count()}");

    }

    public void runStarTwo()
    {
        // var lines = new List<string>() { "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2" };
        var claimsSet = new HashSet<PointWithReference>();
        var contestedClaimsSet = new HashSet<PointWithReference>();
        // Make a coordinate system that starts from 0,0 in the top left corner
        foreach (var line in lines)
        {
            var distanceFromLeft = Int32.Parse(line.Split("@ ")[1].Split(",")[0]);
            var distanceFromTop = Int32.Parse(line.Split(",")[1].Split(":")[0]);
            var width = Int32.Parse(line.Split(" ").Last().Split("x")[0]);
            var height = Int32.Parse(line.Split(" ").Last().Split("x")[1]);
            // System.Console.WriteLine($"distanceFromLeft: {distanceFromLeft}");
            // System.Console.WriteLine($"distanceFromTop: {distanceFromTop}");
            // System.Console.WriteLine($"width: {width}");
            // System.Console.WriteLine($"length: {height}");

            // We need to calculate the points for this thing.

            // For each point on the x-axis, calculate that point, and all corresponding points on the y axis
            foreach (var xPoint in Enumerable.Range(distanceFromLeft, width))
            {
                foreach (var yPoint in Enumerable.Range(distanceFromTop, height))
                {

                    var pointString = $"{xPoint}, {yPoint}";
                    var pointWithRef = new PointWithReference(){point = pointString, reference = line};
                    System.Console.WriteLine($"Point taken up: {pointString} ");

                    // Check whether or not the claim is in the claimsSet
                    if (claimsSet.Contains(pointWithRef))
                    {
                        // TODO here you can easily see that *this* claim does not belong - but what about the previous claim? Keep a reference
                        // TODO here we want to keep a set? of all invalidated claims, then later on we can loop through claims that aren't invalidted
                        // to it in the set?
                        contestedClaimsSet.Add(pointWithRef);
                    }
                    else
                    {
                        claimsSet.Add(pointWithRef);
                    }

                }
            }


        }

        System.Console.WriteLine("Claimsset");
        claimsSet.ToList().ForEach(System.Console.WriteLine);
        System.Console.WriteLine("contestedClaimsSet");
        contestedClaimsSet.ToList().ForEach(System.Console.WriteLine);
        System.Console.WriteLine($"Contested claims: {contestedClaimsSet.Count()}");

    }

}

class PointWithReference {
    public string point;
    public string reference;

    public override int GetHashCode()
    {
        return point.GetHashCode();
    }
}