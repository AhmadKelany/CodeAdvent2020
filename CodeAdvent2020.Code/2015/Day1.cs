using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent.Code._2015
{
    public class Day1
    {
        private static string GetInput() => File.ReadAllText("2015/InputFiles/Day1.txt");
        public static int Part1()
        {
            string input = GetInput();
            int result = input.Select(c => c == '(' ? 1 : -1).Sum();
            Screen.WriteLine($"Result = {result}", ConsoleColor.Green);
            return result;
        }
        public static int Part2()
        {
            string input = GetInput();
            int index = 0;
            int position = 0;
            while(position > -1)
            {
                position += input[index++] == '(' ? 1 : -1;
            }
            int result = index;
            Screen.WriteLine($"Result = {result}", ConsoleColor.Green);
            return result;

        }
    }
}
