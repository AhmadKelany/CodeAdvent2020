using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodeAdvent2020.Code._2020
{
    public static class Day4
    {
        public static List<string> GetPassports() => File.ReadAllText("InputFiles/Day4.txt").Split(Environment.NewLine + Environment.NewLine).ToList();


        public static int Part1() => GetPassports().Count(Part1IsValid);



        public static int Part2() => GetPassports().
            Count(p => Part1IsValid(p) && GetKeyValuePairs(p).All(Part2IsValid));

        public static string[] GetKeyValuePairs(string passport) => passport.Split(new[] { "\r\n", " " }, StringSplitOptions.None);

        public static bool Part1IsValid(string passport)
        {

            var keys = GetKeyValuePairs(passport).Select(s => s.Substring(0, 3));
            var requiredKeys = Rules.Select(r => r.Title);
            var result = requiredKeys.Intersect(keys);
            return result.Count() == Rules.Count;
        }

        public static bool Part2IsValid(string keyValuePair)
        {
            var data = keyValuePair.Split(':');
            string inputTitle = data[0];
            string inputValue = data[1];
            if (inputTitle == "cid") return true;
            var rule = Rules.FirstOrDefault(r => r.Title == inputTitle);
            if (rule == null) return false;
            if (!Regex.IsMatch(inputValue, rule.Regex)) return false;
            if (!rule.IsNumeric) return true;
            int value = 0;
            if (rule.Title == "hgt")
            {
                decimal conversionFactor = inputValue.EndsWith("in") ? 2.54m : 1m;
                inputValue = inputValue.Substring(0, inputValue.Length - 2);
                value = (int)Math.Round(Convert.ToDecimal(inputValue) * conversionFactor);
            }
            else
            {
                value = Convert.ToInt32(inputValue);
            }

            return value >= rule.Min && value <= rule.Max;

        }

        public record Rule(string Title, bool IsNumeric, int Min, int Max, string Regex);
        public static List<Rule> Rules
        {
            get
            {
                return new List<Rule>() {
                    new Rule("byr" , true , 1920 , 2002 , @"^\d{4}$"),
                    new Rule("iyr" , true , 2010 , 2020 , @"^\d{4}$"),
                    new Rule("eyr" , true , 2020 , 2030 , @"^\d{4}$"),
                    new Rule("hgt" , true , 150 , 193 , @"^(\d{2}in|\d{3}cm)$"),
                    new Rule("hcl" , false ,0 , 0 , @"^#[0-9a-f]{6}$"),
                    new Rule("ecl" , false , 0 , 0 , @"^(amb|blu|brn|gry|grn|hzl|oth)$"),
                    new Rule("pid" , false , 0 , 0 , @"^\d{9}$")
                };
            }
        }
    }
}
