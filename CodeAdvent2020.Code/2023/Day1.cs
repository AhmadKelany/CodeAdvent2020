using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent.Code._2023;

public class Day1
{
    static List<string> GetInput() => File.ReadAllLines("2023/InputFiles/Day1.txt").ToList();

    public static int GetNumber(string line)
    {
        char c1 = char.MinValue;
        char c2 = char.MinValue;
        foreach (char c in line)
        {
            if (char.IsDigit(c))
            {
                c1 = c1 == char.MinValue ? c : c1;
                c2 = c;
            }
        }
        return int.Parse($"{c1}{c2}");
    }


    public static string GetModifiedLine(string line)
    {
        Dictionary<string, string> wordsValues = new()
        {
            { "one" ,  "1"} ,
            { "two" ,  "2"} ,
            { "three" ,  "3"} ,
            { "four" ,  "4"} ,
            { "five" ,  "5"} ,
            { "six" ,  "6"} ,
            { "seven" ,  "7"} ,
            { "eight" ,  "8"} ,
            { "nine" ,  "9"} ,
        };
        var keysWithIndexs = wordsValues.
            Keys.
            Select(k => new 
            {
                Key = k ,
                FirstIndex = line.IndexOf(k) ,
                LastIndex = line.LastIndexOf(k)
            });
        var firstOccurence = keysWithIndexs.
            Where(x => x.FirstIndex >= 0).
            OrderBy(x => x.FirstIndex).
            FirstOrDefault();

        var lastOccurence = keysWithIndexs.
            Where(x => x.LastIndex >= 0).
            OrderByDescending(x => x.LastIndex).
            FirstOrDefault();


        if (firstOccurence != null)
        {
            line = line.Substring(0 ,
                firstOccurence.FirstIndex) + 
                wordsValues[firstOccurence.Key] +
                line.Substring(firstOccurence.FirstIndex + 1 );
        }
        if (lastOccurence != null)
        {
            line = line.Substring(0 ,
                lastOccurence.LastIndex) + 
                wordsValues[lastOccurence.Key] +
                line.Substring(lastOccurence.LastIndex + 1 );
        }

        return line;

    }
    public static void Part1()
    {
        List<string> lines = GetInput();
        int result = lines.Select(GetNumber).Sum();
        Screen.WriteLine($"Part 1 Result = {result}", ConsoleColor.Green);
    }

    public static void Part2()
    {
        List<string> lines = GetInput();
        int result = lines.Select(GetModifiedLine).Select(GetNumber).Sum();
        Screen.WriteLine($"Part 2 Result = {result}", ConsoleColor.Green);
    }
}
