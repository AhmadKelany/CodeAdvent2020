using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodeAdvent2020.Code
{
    public class Day7
    {
        public record BagContent(string Color, int Count);
        public record Bag(string Color, List<BagContent> Contents);
        private static List<Bag> Bags = new List<Bag>();

        public static List<string> GetRules() => File.ReadAllLines("InputFiles/Day7.txt").ToList();
        public static List<string> GetBagColors() => GetRules().Select(s => s.Substring(0, s.IndexOf("bags")-1)).ToList();
        public static void PopulateBags()
        {
            var rules = GetRules();
            var result = new List<Bag>();
            foreach (var rule in rules)
            {
                var matches = Regex.Match(rule, @"(\w+ \w+) bags contain (.+)");
                string color = matches.Groups[1].Value;
                var bagContents = new List<BagContent>();
                foreach (var content in matches.Groups[2].Value.Split(","))
                {
                    if (content.StartsWith("no")) continue;
                    var contentMatch = Regex.Match(content, @"(\d+) (\w+ \w+)");
                    string contentColor = contentMatch.Groups[2].Value;
                    int contentCount = int.Parse(contentMatch.Groups[1].Value);
                    bagContents.Add(new BagContent(contentColor, contentCount));
                }
                result.Add(new Bag(color, bagContents));
            }
            Bags = result;
        }

        public static List<string> GetColorsContaining(List<string> containedColors)
        {
            var result = GetRules().
                Where(s =>  containedColors.Any(c => s.Contains(c) && !s.StartsWith(c))).
                Select(s => s.Substring(0, s.IndexOf("bags") - 1)).ToList();

            return result;
        }

        public static int GetBagsCount(string color)
        {
            int result = 0;
            var bag = Bags.First(b => b.Color == color);
            if (bag.Contents.Count > 0)
            {
                result = bag.Contents.Sum(c => c.Count);
                foreach (var content in bag.Contents)
                {
                    result += content.Count * GetBagsCount(content.Color);
                }

            }

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


        public static int Part2()
        {
            PopulateBags();
            int count = GetBagsCount("shiny gold");
            return count;
        }
    }
}
