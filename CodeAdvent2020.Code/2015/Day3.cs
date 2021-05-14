using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent.Code._2015
{
    public class Day3
    {
        static string GetInput() => File.ReadAllText("2015/InputFiles/Day3.txt");

        public static int Part1() => GetSeenCount(GetInput(), 1);
        public static int Part2() => GetSeenCount(GetInput(), 2);

        public static int GetSeenCount(string input , int moversCount)
        {
            var values = new HashSet<string>();
            var locations = new Dictionary<int, string>();
            string startLocation = "0,0";
            for (int i = 0; i < moversCount; i++)
            {
                locations[i] = startLocation;
            }
            values.Add(startLocation);
            int currentMoverIndex = 0;
            foreach (var c in input)
            {
                locations[currentMoverIndex] = GetNextHouseLocation(locations[currentMoverIndex], c);
                values.Add(locations[currentMoverIndex]);
                currentMoverIndex = currentMoverIndex == moversCount - 1 ? 0 : currentMoverIndex + 1;
            }
            var result = values.Count;
            Screen.WriteLine($"Result = {result:N0}", ConsoleColor.Green);
            return result;

        }


        public static string GetNextHouseLocation(string previousLocation , char direction)
        {
            int[] location = previousLocation.Split(',').Select(int.Parse).ToArray();
            switch (direction)
            {
                case '^':
                    location[1] -= 1;
                    break;
                case 'v':
                    location[1] += 1;
                    break;
                case '>':
                    location[0] += 1;
                    break;
                case '<':
                    location[0] -= 1;
                    break;
                default:
                    break;
            }
            return $"{location[0]},{location[1]}";
        }
    }
}
