using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeAdvent.Code._2015
{
    public class Day5
    {
        static List<string> GetInput() => File.ReadAllLines("2015/InputFiles/Day5.txt").ToList();

        public static bool HasAtLeast3Vowels(string s)
        {
            return s.Count(c => "aeiou".Contains(c)) >= 3;
        }
        public static bool HasAtLeastOneDuplicate(string s)
        {
            return Regex.IsMatch(s, @"(\w)\1+");
        }

        public static bool  NotContainingNaughtyStrings(string s)
        {
            List<string> n = new List<string>() { "ab", "cd", "pq", "xy" };
            return n.All(ns => !s.Contains(ns));
        }

        public static int Part1()
        {
            var rules = new List<Func<string, bool>>() { HasAtLeast3Vowels, HasAtLeastOneDuplicate, NotContainingNaughtyStrings };
            var result = GetInput().Count(s => rules.All(f => f(s)));
            Screen.WriteLine($"Part 1 result = {result}");
            return result;
        }

        public static int Part2()
        {
            var result = GetInput().Count(s => Regex.IsMatch(s, @"(\w).\1") && Regex.IsMatch(s , @"(\w{2}).*\1"));
            Screen.WriteLine($"Part 2 result = {result}");
            return result;

        }
    }
}
