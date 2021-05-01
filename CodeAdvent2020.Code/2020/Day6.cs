using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeAdvent.Code._2020
{
    public class Day6
    {
        public static List<string> GetAnswers() => File.ReadAllText("InputFiles/Day6.txt").Split(Environment.NewLine + Environment.NewLine).ToList();
        public static int Part1() => GetAnswers().Select(s => s.Replace(Environment.NewLine , "").GroupBy(c => c).Count()).Sum();
        public static int Part2() => GetAnswers().
            Select(s => s.Split(Environment.NewLine).Aggregate((x, y) => new string( x.Intersect(y).ToArray())).Length).Sum();

    }
}
