using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeAdvent.Code._2020
{
    public class Day3
    {
        public static List<string> GetInputs() => File.ReadAllLines("InputFiles/Day3.txt").ToList();
        public static int Part1() => GetTreesCount(new Slope(3, 1));

        public static long Part2()
        {
            var slopes = new List<Slope>() {
                new Slope(1,1) ,
                new Slope(3,1) ,
                new Slope(5,1) ,
                new Slope(7,1) ,
                new Slope(1,2)
            };
            long result = slopes.Select(s => (long)GetTreesCount(s)).Aggregate((x, y) => x * y);
            return result;
        }


        public record Slope(int xDisplacement, int yDisplacement);
        private static int GetTreesCount(Slope slope)
        {
            int x = slope.xDisplacement;
            int treesCount = 0;
            var inputs = GetInputs();
            int patternLength = inputs[0].Length;
            for (int i = slope.yDisplacement; i < inputs.Count; i += slope.yDisplacement)
            {
                if (inputs[i][x] == '#') treesCount++;

                x += slope.xDisplacement;
                if (x > patternLength - 1) x -= patternLength;
                // good alternative for the previous two lines:
                // x = (x+slope.xDisplacement)%patternLength;
            }
            return treesCount;
        }
    }
}
