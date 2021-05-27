using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent.Code._2015
{
    public class Day6
    {
        enum eCommand
        {
            TurnOn,
            TurnOff,
            Toggle
        }
        record Instruction (eCommand Command , Point Point1 , Point Point2);

        static void ApplyInstruction(Instruction instruction,Func<int,eCommand,int> rule)
        {
            for (int x = instruction.Point1.X; x <= instruction.Point2.X; x++)
            {
                for (int y = instruction.Point1.Y; y <= instruction.Point2.Y; y++)
                {
                    Matrix[x, y] = rule(Matrix[x, y], instruction.Command);
                }
            }
        }
        static int Part1Rule(int input,eCommand command)
        {
            return command switch
            {
                eCommand.TurnOn => 1,
                eCommand.TurnOff => 0,
                eCommand.Toggle => input == 0 ? 1 : 0
            };
        }
        static int Part2Rule(int input,eCommand command)
        {
            return command switch
            {
                eCommand.TurnOn => input+=1,
                eCommand.TurnOff => input == 0 ? 0 : input-=1,
                eCommand.Toggle => input +=2
            };

        }
        static Instruction GetInstruction(string s)
        {
            var t = s.Split( ' ' );
            eCommand command = t[0] switch
            {
                "toggle" => eCommand.Toggle,
                "turn" => t[1] == "on" ? eCommand.TurnOn : eCommand.TurnOff
            };
            int coordinateIndex = t.Length - 3;
            var p1 = t[coordinateIndex].Split(',').Select(int.Parse).ToArray();
            var p2 = t[coordinateIndex + 2].Split(',').Select(int.Parse).ToArray();
            Point point1 = new Point(p1[0], p1[1]);
            Point point2 = new Point(p2[0], p2[1]);
            return new Instruction(command, point1, point2);
        }
        static void ModifyMatrix(Func<int, eCommand, int> rule)
        {
            foreach (var instruction in GetInstructions())
            {
                ApplyInstruction(instruction, rule);
            }

        }
        static List<string> GetInput() => File.ReadAllLines("2015/InputFiles/Day6.txt").ToList();
        static List<Instruction> GetInstructions() => GetInput().Select(GetInstruction).ToList();

        static int[,] Matrix = new int[1000,1000];
        public static int Part1()
        {
            ModifyMatrix(Part1Rule);

            var lit = Matrix.Cast<int>().Count(n => n == 1);
            Screen.WriteLine($"{lit}");
            return lit;
        }

        public static int Part2()
        {
            ModifyMatrix(Part2Rule);
            var brightness = Matrix.Cast<int>().Sum();
            Screen.WriteLine($"{brightness}");
            return brightness;

        }
    }
}
