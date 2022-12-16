using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent.Code._2022;

public class Day1
{
    public static string[] GetData() =>
    File.ReadAllLines(@"2022/InputFiles/Day1.txt");
    public static string[] GetSampleData() =>
    File.ReadAllLines(@"2022/InputFiles/Day1Sample.txt");

    public static int Part1()
    {
        var d = GetData().AsSpan<string>();
        int max = 0;
        int elfTotal = 0;
        int i = 0;
        while (i < d.Length)
        {
            int.TryParse(d[i], out int item);
            elfTotal += item;
            if (d[i] == "" || i == d.Length -1)
            {
                max = Math.Max(max, elfTotal);
                elfTotal = 0;
            }
            i++;
        }
        Screen.WriteLine($"result = {max}", ConsoleColor.Green);
        return max;
    }

    public static int Part2()
    {
        return 0;
    }
}
