using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
public class Program
{
    public static void Main(string[] args)
    {
        var safeReports = 0;

        var reports = File.ReadAllLines("input.txt")
            .Select(line => line.Split(' ')
                .Select(n => int.Parse(n)).ToList())
            .ToList();

        foreach (var report in reports)
        {
            foreach (var level in report)
            {
                Console.Write(level);
                Console.Write(" ");
            }
            Console.WriteLine();
        }

        foreach (var report in reports)
        {
            if (IsSafe(report) && OrderedCorrectly(report))
            {
                safeReports++;
            }
            else 
            {
                for (int i = 0; i < report.Count; i++)
                {
                    var reportCopy = report.ToList();
                    reportCopy.RemoveAt(i);
                    if (IsSafe(reportCopy) && OrderedCorrectly(reportCopy))
                    {
                        safeReports++;
                        break;
                    }
                }
            }
          
        }
        Console.WriteLine($"Safe reprots:{safeReports} ");

    }
    public static bool IsSafe(List<int> report)
    {
        
        var differences = report.Zip(report.Skip(1), (x, y) => y - x).ToList();
        return differences.All(diff => (diff >= 1 && diff <= 3) || (diff <= -1 && diff >= -3));
    }

    public static bool OrderedCorrectly(List<int> report)
    {

        var orderedByAsc = report.OrderBy(d => d);
        if (report.SequenceEqual(orderedByAsc))
        {
            Console.WriteLine("Ordered by Asc");
            return true;
        }

        var orderedByDsc = report.OrderByDescending(d => d);
        if (report.SequenceEqual(orderedByDsc))
        {
            Console.WriteLine("Ordered by Dsc");
            return true;
        }

        return false;

    }
}





