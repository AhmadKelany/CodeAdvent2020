using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeAdvent.Code._2015
{
    public class Day8
    {
        public static List<string> GetInput() => File.ReadAllLines("2015/InputFiles/Day8.txt").ToList();
        public static string GetInMemoryString(string s)
        {
            s = s.Substring(1,s.Length-2).Replace("\\\"", "\"");
            s = s.Replace("\\\\", "?");
            s = Regex.Replace(s, @"\\x[0-9a-f]{2}", "?");
            return s;
        }
        public static void Part1()
        {
            var result = GetInput()
                .Sum(x => x.Length  - GetInMemoryString(x).Length);
            Screen.WriteLine($"Part 1 result = {result}" , ConsoleColor.Cyan);
        }
    }

}
