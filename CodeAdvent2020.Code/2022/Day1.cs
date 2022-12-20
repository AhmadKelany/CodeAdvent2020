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
        int max = GetTopElfTotals(d, 1)[0];
        Screen.WriteLine($"result = {max}", ConsoleColor.Green);
        return max;
    }

    public static int[] GetTopElfTotals(Span<string> values , int count)
    {
        HashSet<int> result = new HashSet<int>();
        
        int elfTotal = 0;
        int i = 0;
        while (i < values.Length)
        {
            int.TryParse(values[i], out int item);
            elfTotal += item;
            if (values[i] == "" || i == values.Length - 1)
            {
                result.Add(elfTotal);
                elfTotal = 0;
            }
            i++;
        }
        return result.OrderByDescending(n => n).Take(count).ToArray();
    }

    public static int Part2()
    {
        var d = GetData().AsSpan<string>();
        int max = GetTopElfTotals(d, 3).Sum();
        Screen.WriteLine($"result = {max}", ConsoleColor.Green);
        return max; ;
    }
}
