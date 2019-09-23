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
        var freePointsSet = new HashSet<PointWithReference>();
        var contestedPointsSet = new HashSet<PointWithReference>();
        
        // Make a coordinate system that starts from 0,0 in the top left corner
        foreach (var line in lines)
        {
            var distanceFromLeft = Int32.Parse(line.Split("@ ")[1].Split(",")[0]);
            var distanceFromTop = Int32.Parse(line.Split(",")[1].Split(":")[0]);
            var width = Int32.Parse(line.Split(" ").Last().Split("x")[0]);
            var height = Int32.Parse(line.Split(" ").Last().Split("x")[1]);
            var id = Int32.Parse(line.Split(" ")[0].Split("#")[1]);

            // For each point on the x-axis, calculate that point, and all corresponding points on the y axis
            foreach (var xPoint in Enumerable.Range(distanceFromLeft, width))
            {
                foreach (var yPoint in Enumerable.Range(distanceFromTop, height))
                {

                    var pointString = $"{xPoint}, {yPoint}";
                    var pointWithRef = new PointWithReference(){point = pointString, reference = line};

                    // Check whether or not the claim is in the claimsSet
                    if (freePointsSet.Contains(pointWithRef))
                    {
                        // System.Console.WriteLine("Contains");
                        freePointsSet.Remove(pointWithRef);
                        contestedPointsSet.Add(pointWithRef);

                    }
                    else
                    {
                        // System.Console.WriteLine("Does not contain");
                        freePointsSet.Add(pointWithRef);
                    }

                }
            }
        }

        System.Console.WriteLine($"{freePointsSet.Count()}");
        foreach (var point in freePointsSet)
        {
            System.Console.WriteLine($"{point.reference} : {point.point}");
        }

        

        System.Console.WriteLine($"Contested claims: {contestedPointsSet.Count()}");
    }

}

class PointWithReference {
    public string point;
    public string reference;

    public override int GetHashCode()
    {
        return point.GetHashCode();
    }

    public override bool Equals(object obj){
        if (obj is PointWithReference){
            return (obj as PointWithReference).point == this.point;
        }
        return false;
    }
}