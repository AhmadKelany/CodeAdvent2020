using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2020.Code
{
    public class Day3
    {
        public static List<string> GetInputs() => File.ReadAllLines("InputFiles/Day3.txt").ToList();
        private static string inputTest = @"..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#";


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
            var input = @"..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#".Split(Environment.NewLine).ToList();
            int x = slope.xDisplacement;
            int treesCount = 0;
            //var inputs = input;
            var inputs = GetInputs();
            int patternLength = inputs[0].Length;
            for (int i = 1; i < inputs.Count; i += slope.yDisplacement)
            {
                if (inputs[i][x] == '#') treesCount++;
                x += slope.xDisplacement;
                if (x > patternLength - 1) x -= patternLength;
            }
            return treesCount;
        }
    }
}
