using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2020.Code
{
    public class Day7
    {
        public static List<string> GetRules() => File.ReadAllLines("InputFiles/Day7.txt").ToList();
        public static List<string> GetBagColors() => GetRules().Select(s => s.Substring(0, s.IndexOf("bags")-1)).ToList();

        public static List<string> GetColorsContaining(List<string> containedColors)
        {
            var result = GetRules().
                Where(s =>  containedColors.Any(c => s.Contains(c) && !s.StartsWith(c))).
                Select(s => s.Substring(0, s.IndexOf("bags") - 1)).ToList();

            return result;
        }



        public static int Part1()
        {
            var containedColors = new List<string> { "shiny gold" };
            int foundIterationCount = 0;
            var totalContainingColors = new List<string>();
            do
            {
                containedColors = GetColorsContaining(containedColors);
                totalContainingColors.AddRange(containedColors);
                foundIterationCount = containedColors.Count;
            } while (foundIterationCount > 0);

            return totalContainingColors.Distinct().Count();

        }
    }
}
