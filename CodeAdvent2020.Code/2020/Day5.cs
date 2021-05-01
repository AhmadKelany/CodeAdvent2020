using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeAdvent2020.Code._2020
{
    public class Day5
    {
        public static List<string> GetPasses() => File.ReadAllText("InputFiles/Day5.txt").Split(Environment.NewLine).ToList();
        public static int GetSeatId(string pass)
        {
            int row = GetCoordinate(pass.Substring(0, 7), 128);
            int column = GetCoordinate(pass.Substring(7, 3), 8);
            return (row * 8) + column;
        }

        public static List<int> GetSeatIds() => GetPasses().Select(GetSeatId).ToList();
        public static int GetCoordinate(string directions , int possiblesCount)
        {
            int lowestPossible = 0;
            for (int i = 0; i < directions.Length; i++)
            {
                CalculateLowestPossible(ref lowestPossible,ref possiblesCount , directions[i]);
            }
            return lowestPossible;
        }
        public static void CalculateLowestPossible(ref int lowestPossible ,ref int possiblesCount , char direction)
        {
            var upDirections = new[] { 'B', 'R' };
            possiblesCount /= 2;
            if (upDirections.Contains(direction)) lowestPossible += possiblesCount;
        }

        public static int Part2()
            => Enumerable.Range(8, Part1() - 8).Except(GetSeatIds()).FirstOrDefault();


        public static int Part1()
            => GetSeatIds().Max();

    }
}
