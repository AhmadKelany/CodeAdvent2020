using CodeAdvent2020.Code;
using System;

namespace CodeAdvent2020.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = Day11.Part1();
            Screen.WriteLine($"The Count is:{count}", ConsoleColor.Cyan);
            System.Console.ReadLine();
        }
    }
}
