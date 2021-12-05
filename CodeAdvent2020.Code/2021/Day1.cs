using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent.Code._2021
{
    public class Day1
    {
        public static List<int> GetData() =>
    File.ReadAllLines("2021/InputFiles/Day1.txt").
    Select(int.Parse).ToList();

        public static int Part1()
        {
            var data = GetData();
            var result = data.Zip(data.Skip(1 )).Count(x => x.Second > x.First);
            Screen.WriteLine($"result = {result}", ConsoleColor.Green);
            return result;
        }

        public static int Part2()
        {
            return 0;
        }
    }
}
