using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeAdvent.Code._2024;

public static class Day3
{
    static string GetInput() => File.ReadAllText("2024/InputFiles/Day3.txt");
    static string GetSampleInput() => File.ReadAllText("2024/InputFiles/Day3Sample.txt");
    static string mulPattern = @"mul\(([0-9]{1,3}),([0-9]{1,3})\)";
    static int GetProduct(Match match)
    {
        return (int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value));
    }
    public static void Part1()
    {
        string input = GetInput();
        int result = GetSumOfProducts(input);
        Screen.WriteLine($"Part 1 Result = {result}", ConsoleColor.Cyan);

    }

    private static int GetSumOfProducts(string input)
    {
        MatchCollection matches = Regex.Matches(input, mulPattern);
        int result = 0;
        foreach (Match match in matches)
        {
            result += GetProduct(match);
        }

        return result;
    }

    public static void Part2()
    {
        var input = GetInput();
        int startIndex = 0;
        int endIndex = 0;
        bool currentlyDo = true;
        int result = 0;
        while (startIndex < input.Length)
        {
            string nextString = currentlyDo? "don't()" : "do()";
            endIndex= input.IndexOf(nextString, startIndex);
            if (endIndex == -1)
            {
                endIndex = input.Length-1;
            }
            if (currentlyDo)
            {
                result += GetSumOfProducts(input.Substring(startIndex, endIndex - startIndex));
            }
            currentlyDo = !currentlyDo;
            startIndex = endIndex + nextString.Length;

        }
        Screen.WriteLine($"Part 2 Result = {result}", ConsoleColor.Cyan);
    }
}
