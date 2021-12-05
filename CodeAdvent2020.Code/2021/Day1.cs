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
            var firstSequence = data.Zip(data.Skip(1)).Zip(data.Skip(2));
            var secondSequence = data.Skip(3).Zip(data.Skip(4)).Zip(data.Skip(5));
            var result = firstSequence.Zip(secondSequence).Count(x => x.First.First.First + x.First.First.Second + x.First.Second  < x.Second.First.First + x.Second.First.Second + x.Second.Second);
            Screen.WriteLine($"result = {result}", ConsoleColor.Green);
            return result;

        }
    }
}
