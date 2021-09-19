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
        public static List<string> GetInput() => File.ReadAllLines("2015/InputFiles/Day8.txt").Select(s=>s.Trim('"')).ToList();
        public static (int codeLength,int memoryLength) GetStringLengths(string s)
        {
            s = s.Replace("\n", "");
            int codeLength = s.Length + 2;
            s = s.Replace("\\\"" , "i" );
            s = Regex.Replace(s, @"\\x[0-9]{2}", "i");
            s = s.Replace("\\", "i");
            int memoryLength = s.Length;
            return (codeLength,memoryLength);
        }
        public static string GetInMemoryString(string s)
        {
            s = s.Replace("\\\"", "i");
            s = Regex.Replace(s, @"\\x[0-9]{2}", "i");
            s = s.Replace("\\\\", "i");
            return s;
        }
        public static void Part1()
        {
            var result = GetInput()
                .Sum(x => x.Length + 2  - GetInMemoryString(x).Length);
            Screen.WriteLine($"Part 1 result = {result}" , ConsoleColor.Cyan);
        }
    }

}
