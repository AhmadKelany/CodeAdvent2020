using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent.Code._2024;

public static class Day2
{
    static string[] GetInput() => File.ReadAllLines("2024/InputFiles/Day2.txt");
    static string[] GetSampleInput() => File.ReadAllLines("2024/InputFiles/Day2Sample.txt");

    static int[] GetLevels(string line)
    {
        var splits = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return splits.Select(int.Parse).ToArray();
    }

    static bool IsSafe(int[] levels)
    {
        if (levels[0] == levels[1]) return false;
        int factor = levels[1] > levels[0] ? 1 : -1;
        int index = 1;
        while (index < levels.Length) 
        { 
            if(levels[index] == levels[index - 1] || factor * (levels[index] - levels[index-1]) > 3) return false;
            index++;
        }
        return true;
    }
    public static void Part1()
    {
        var lines = GetSampleInput();
        var levels = lines.
            Select(GetLevels);
        int result = levels.
            Count(IsSafe);
        Screen.WriteLine($"Part 1 Result = {result}", ConsoleColor.Cyan);
    }
}
