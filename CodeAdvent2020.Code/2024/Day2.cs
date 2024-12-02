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

    static bool IsSafe(int[] levels, int tolerateCount = 0)
    {
        if (levels[0] == levels[1]) return false;
        int factor = levels[1] > levels[0] ? 1 : -1;
        int index = 1;
        while (index < levels.Length) 
        { 
            int diff = levels[index] - levels[index - 1];
            if (diff == 0 || diff / Math.Abs(diff) != factor || Math.Abs( diff) > 3) tolerateCount--;
            if(tolerateCount < 0) return false;
            index++;
        }
        return true;
    }
    public static void Part1()
    {
        var lines = GetInput();
        var levels = lines.
            Select(GetLevels);
        int result = levels.
            Count(l => IsSafe(l));
        Screen.WriteLine($"Part 1 Result = {result}", ConsoleColor.Cyan);
    }
    public static void Part2()
    {
        var lines = GetInput();
        var levels = lines.
            Select(GetLevels);
        int result = levels.
            Count(l => IsSafe(l,1));
        Screen.WriteLine($"Part 2 Result = {result}", ConsoleColor.Cyan);
    }
}
