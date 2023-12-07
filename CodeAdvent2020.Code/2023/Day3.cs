using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent.Code._2023;

public class Day3:Day
{
    const string Symbols = @"!@#$%^&*+-*/\";
    public record Point(int X , int Y);
    public record PartNumber(int Number, int X , int[] Ys);
    public static List<PartNumber> GetPartNumbers(List<string> lines)
    {
        var parts = new List<PartNumber>();
        string currentNumber = "";
        int currentY = -1;
        for (int x = 0; x < lines.Count; x++)
        {
            char[] allSeparators = ['.', .. Symbols.ToArray()];
            var numbers = lines[x].Split( allSeparators , StringSplitOptions.RemoveEmptyEntries);
            foreach (var number in numbers)
            {
                int y = lines[x].IndexOf(number);
                List<Point> points = new List<Point>();
                for (int z = 0; z <= numbers.Length; z++)
                {
                    points.Add(new(x, y + z));
                }
                parts.Add(new(int.Parse(number), points));
            }
        }
        return parts;
    }
}
