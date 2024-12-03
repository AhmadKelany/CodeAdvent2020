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

    static bool IsValidTransition(int level1, int level2, int factor)
    {
        int diff = level2 - level1;
        return diff != 0 && diff / Math.Abs(diff) == factor && Math.Abs(diff) <= 3;
    }
    static bool IsSafeNoTolerance(int[] levels)
    {
        if (levels[0] == levels[1]) return false;

        int factor = levels[1] > levels[0] ? 1 : -1;
        int index = 1;
        while (index < levels.Length)
        {
            if (!IsValidTransition(levels[index - 1], levels[index], factor))
            {
                return false;
            }
            index++;
        }
        return true;
    }
    static bool IsSafeWithTolerance(int[] levels)
    {
        if(IsSafeNoTolerance(levels)) return true;
        for (int i = 0; i < levels.Length; i++)
        {
            var m = levels.Where((n, ix) => ix != i).ToArray();
            if (IsSafeNoTolerance(m)) return true;
        }
        return false;
    }
    public static void Part1()
    {
        var lines = GetInput();
        var levels = lines.
            Select(GetLevels);
        int result = levels.
            Count(IsSafeNoTolerance);
        Screen.WriteLine($"Part 1 Result = {result}", ConsoleColor.Cyan);
    }
    public static void Part2()
    {
        var lines = GetInput();
        var levels = lines.
            Select(GetLevels);
        int result = levels.
            Count(IsSafeWithTolerance);
        Screen.WriteLine($"Part 2 Result = {result}", ConsoleColor.Cyan);
    }
}
