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

        public static int Part1()
        {
            string input = GetInput();
            var values = new HashSet<string>();
            string currentLocation = "0,0";
            foreach (var c in input)
            {
                values.Add(currentLocation);
                currentLocation = GetNextHouseLocation(currentLocation, c);
            }
            var result = values.Count;
            Screen.WriteLine($"Result = {result:N0}", ConsoleColor.Green);
            return result;
        }
        public static int Part2()
        {
            string input = GetInput();
            var values = new HashSet<string>();
            string santaLocation = "0,0";
            string roboLocation = "0,0";
            bool isSantaTurn = false;
            values.Add(santaLocation);
            values.Add(roboLocation);

            foreach (var c in input)
            {
                if(isSantaTurn)
                {
                    santaLocation = GetNextHouseLocation(santaLocation, c);
                    values.Add(santaLocation);
                }
                else
                {
                    roboLocation = GetNextHouseLocation(roboLocation, c);
                    values.Add(roboLocation);
                }
                isSantaTurn = !isSantaTurn;
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
