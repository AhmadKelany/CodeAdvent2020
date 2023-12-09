using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent.Code._2023;

public class Day4
{
    static string[] GetInput() => File.ReadAllLines("2023/InputFiles/Day4.txt");
    static string[] GetSampleInput() => File.ReadAllLines("2023/InputFiles/Day4Sample.txt");


    public static void Part1()
    {
        var lines = GetInput();
        int result = lines.
            Select(l => l.Split([':' , '|'])).
            Select(s => (int)Math.Pow(2 ,
                s[1].Trim().Split(' ' , StringSplitOptions.RemoveEmptyEntries).
                Intersect(s[2].Trim().Split(' ' , StringSplitOptions.RemoveEmptyEntries)).Count() - 1 )).
            Sum();

        Screen.WriteLine($"Part 1 Result = {result}", ConsoleColor.Green);

    }
}
