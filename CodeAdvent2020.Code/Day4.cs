using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2020.Code
{
    public class Day4
    {
        public static List<string> GetInputs() => File.ReadAllText("InputFiles/Day4.txt").Split(Environment.NewLine + Environment.NewLine).ToList();


        public static int Part1() => GetInputs().Where(IsValid).Count();

        public static bool IsValid(string passport)
        {

            var keys = passport.Split(new[]{ "\r\n" , " " },StringSplitOptions.None).Select(s => s.Substring(0, 3)).ToList();
            var requiredKeys = new List<string>()
            {
                "byr",
                "iyr",
                "eyr",
                "hgt",
                "hcl",
                "ecl",
                "pid"
            };
            var result = requiredKeys.Intersect(keys);
            return result.Count() == 7;
        }
    }
}
