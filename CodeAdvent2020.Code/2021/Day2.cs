using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CodeAdvent.Code._2021
{
    public static class Day2
    {
        public static List<(string Instruction,int Amount)> GetData() =>
    File.ReadAllLines("2021/InputFiles/Day2.txt").
    Select(x => (x.Split(' ')[0] ,int.Parse( x.Split(' ')[1]))).ToList();

        public static int Part1()
        {
            var data = GetData();
            int x = data.GetCommandAmount("forward");
            int yIncrease = data.GetCommandAmount("down"); 
            int yDecrease = data.GetCommandAmount("up"); 
            int y = yIncrease - yDecrease;
            int result = x * y;
            Screen.WriteLine($"result = {result}", ConsoleColor.Green);
            return result;

        }
        private static int GetCommandAmount(this List<(string Instruction, int Amount)> data , string command)
        {
            int result = data.
                Where(d => d.Instruction == command).
                Sum(d => d.Amount);

            return result;
        }
        public static int Part2()
        {
            var data = GetData();
            int aim = 0;
            int x = 0;
            int y = 0;
            foreach (var command in data)
            {
                switch (command.Instruction)
                {
                    case "forward":
                        x += command.Amount;
                        y += (aim*command.Amount);
                        break;
                    case "up":
                        aim -= command.Amount;
                        break ;
                    case "down":
                        aim += command.Amount;
                        break;
                    default:
                        break;
                }
            }
            int result = x * y;
            Screen.WriteLine($"result = {result}", ConsoleColor.Green);
            return result;

        }
    }
}
