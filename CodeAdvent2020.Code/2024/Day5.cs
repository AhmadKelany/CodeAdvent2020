using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent.Code._2024;

public class Day5
{
    static string GetInput() => File.ReadAllText("2024/InputFiles/Day5.txt");
    static string GetSampleInput() => File.ReadAllText("2024/InputFiles/Day5Sample.txt");

    record Order(int First,int Second);
    static Dictionary<int, int[]> GetOrders(string input)
    {
        string[] s = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
        Dictionary<int, int[]> orders = new();
    }
    
}
