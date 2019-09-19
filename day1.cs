using System.Linq;
public class DayOne {

    public void run(){
        System.Console.WriteLine("Hello from day one!");

        var lines = System.IO.File.ReadAllLines(@"./day1.txt");
        System.Console.WriteLine(lines[0]);

        lines.Aggregate(abc => abc)

    }
}