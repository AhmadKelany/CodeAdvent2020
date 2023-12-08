﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent.Code._2023;

public class Day3
{
    const string Symbols = @"!@#$%^&*+-*/\=_(){}[]?><;'";
    static string[] GetInput() => File.ReadAllLines("2023/InputFiles/Day3.txt");

    private static char[] separators = ['.', .. Symbols];

    public record Point(int X , int Y);
    public record PartNumber(int Number, int X , int[] Ys);
    public static List<PartNumber> GetPartNumbers(string[] lines)
    {
        List<PartNumber> parts = new();
        for (int x = 0; x < lines.Length; x++)
        {
            string line = lines[x];
            parts.AddRange(GetLineParts(x, line));

        }
        return parts;
    }

    public static int[] GetSymbolIndexes(string line, char[] symbols)
    {
        List<int> foundIndexes = new List<int>();
        foreach (char symbol in symbols)
        {
            int index = line.IndexOf(symbol);
            while (index != -1)
            {
                foundIndexes.Add(index);
                index = line.IndexOf(symbol, index + 1);
            }
        }
        return foundIndexes.ToArray();
    }

    public static Point[] GetPointsAdjacentToSymbols(string[] lines , char[] symbols)
    {
        HashSet<Point> points = new HashSet<Point>();
        for(int x = 0;x < lines.Length;x++)
        {
            string line = lines[x];

            var ys = GetSymbolIndexes(line, symbols);

            foreach (int y in ys)
            {
                points.Add(new Point(x-1, y-1));
                points.Add(new Point(x-1, y));
                points.Add(new Point(x-1, y+1));
                points.Add(new Point(x, y-1));
                points.Add(new Point(x, y+1));
                points.Add(new Point(x + 1, y - 1));
                points.Add(new Point(x + 1, y));
                points.Add(new Point(x + 1, y + 1));
            }
        }
        return points.ToArray();
    }
    public static bool PartInPoints(PartNumber part , Point[] points) 
    {
        return points.Any(p => p.X == part.X && part.Ys.Contains(p.Y));
    }


    public static void Part1()
    {
        var lines = GetInput();
        var parts = GetPartNumbers(lines);
        var symbolsAdjacentPoints = GetPointsAdjacentToSymbols(lines, Symbols.ToArray());
        int result = parts.Where( p => PartInPoints(p, symbolsAdjacentPoints)).Sum(p => p.Number);
        Screen.WriteLine($"Part 1 Result = {result}", ConsoleColor.Green);

    }
    private static List<PartNumber> GetLineParts( int x, string line)
    {
        string[] numberStrings = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        int currentIndex = 0;
        List<PartNumber> parts = new();

        foreach (string num in numberStrings)
        {
            int numIndex = line.Substring(currentIndex).IndexOf(num) + currentIndex;
            parts.Add(new(int.Parse(num), x, Enumerable.Range(numIndex, num.Length).ToArray()));
            currentIndex = numIndex + num.Length;
        }
        return parts;
    }
}
