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
            var data = GetData();
            int count = 0;
            for (int i = 0; i < data.Count - 3; i++)
            {
                count += data[i] < data[i + 3] ? 1 : 0;
            }
            Screen.WriteLine($"result = {count}", ConsoleColor.Green);
            return count;

        }
    }
}
