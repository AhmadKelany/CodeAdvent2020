using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2020.Code
{
    public class Day8
    {

        public enum Command { acc , nop , jmp}
        public record Line(Command command , int parameter);
        public static List<Line> GetLines() =>
            File.ReadAllLines("InputFiles/Day8.txt").
            Select(l => new Line(Enum.Parse<Command>(l.Substring(0, 3)), int.Parse(l.Substring(3)))).ToList();
        public static int Part1() {
            var lines = GetLines();
            int accumulator = 0;
            int nextIndex = 0;
            List<int> processedLines = new List<int>();

            while (!processedLines.Contains(nextIndex))
            {
                processedLines.Add(nextIndex);
                var line = lines[nextIndex];
                switch (line.command)
                {
                    case Command.acc:
                        accumulator += line.parameter;
                        nextIndex++;
                        break;
                    case Command.nop:
                        nextIndex++;
                        break;
                    case Command.jmp:
                        nextIndex += line.parameter;
                        break;
                    default:
                        break;
                }

            }
            return accumulator;
        }
        public static int Part2() { return 0; }
    }
}
