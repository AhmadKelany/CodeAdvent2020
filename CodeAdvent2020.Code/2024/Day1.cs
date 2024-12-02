using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent.Code._2024;

public static class Day1
{
    static string[] GetInput() => File.ReadAllLines("2024/InputFiles/Day1.txt");
    static string[] GetSampleInput() => File.ReadAllLines("2024/InputFiles/Day1Sample.txt");
    static (int Num1, int Num2) GetNumbers(string line)
    {
        var splits = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return (int.Parse(splits[0]), int.Parse(splits[1]));
    }

    public static void Part1()
    {
        var lines = GetInput();
        var numbers = lines.
            Select(GetNumbers);
        List<int> list1 = new();
        List<int> list2 = new();
        foreach(var (num1, num2) in numbers)
        {
            list1.Add(num1);
            list2.Add(num2);
        }
        list1.Sort();
        list2.Sort();
        int result = list1.Zip(list2, (num1, num2) => Math.Abs( num1 - num2)).Sum();
        Screen.WriteLine($"Part 1 Result = {result}", ConsoleColor.Cyan);
    }

    public static void Part2()
    {
        var lines = GetInput();
        var numbers = lines.
            Select(GetNumbers);
        List<int> list1 = new();
        List<int> list2 = new();
        foreach (var (num1, num2) in numbers)
        {
            list1.Add(num1);
            list2.Add(num2);
        }
        Dictionary<int, int> dict = new();
        dict = list2.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        int result = list1.
            Select(n => dict.ContainsKey(n)? n * dict[n] : 0).
            Sum();
        Screen.WriteLine($"Part 2 Result = {result}", ConsoleColor.Cyan);
    }
}
