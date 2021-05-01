using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent.Code._2020
{
    public class Day8
    {

        public enum Command { acc, nop, jmp }
        public record Line(Command Command, int Parameter, int Index);
        public static List<Line> GetLines() =>
            File.ReadAllLines("InputFiles/Day8.txt").
            Select((l, i) => new Line(Command:Enum.Parse<Command>(l.Substring(0, 3)),
                                      Parameter: int.Parse(l.Substring(3)),
                                      Index:i)).ToList();
        public static int Part1() => GetAccumulatorAndExitedProperly(GetLines()).Accumulator;
        public static (int Accumulator, bool ExitedProperly) GetAccumulatorAndExitedProperly(List<Line> lines)
        {
            int accumulator = 0;
            int nextIndex = 0;
            bool exitedProperly = false;
            List<int> processedLineIndexes = new List<int>();

            while (!processedLineIndexes.Contains(nextIndex))
            {
                if (nextIndex == lines.Count)
                {
                    exitedProperly = true;
                    break;
                }
                processedLineIndexes.Add(nextIndex);
                var line = lines[nextIndex];
                switch (line.Command)
                {
                    case Command.acc:
                        accumulator += line.Parameter;
                        nextIndex++;
                        break;
                    case Command.nop:
                        nextIndex++;
                        break;
                    case Command.jmp:
                        nextIndex += line.Parameter;
                        break;
                    default:
                        break;
                }
            }

            return (accumulator, exitedProperly);


        }
        public static int Part2()
        {
            var lines = GetLines();
            int firstIndex = -1;
            while (true)
            {
                var lineToChange = lines.FirstOrDefault(l => l.Index > firstIndex && (l.Command == Command.jmp || l.Command == Command.nop));
                firstIndex = lineToChange.Index;
                lineToChange = new Line(lineToChange.Command == Command.jmp ? Command.nop : Command.jmp, lineToChange.Parameter, lineToChange.Index);
                lines[lineToChange.Index] = lineToChange;
                var result = GetAccumulatorAndExitedProperly(lines);
                if (result.ExitedProperly)
                {
                    return result.Accumulator;
                }
                lines[lineToChange.Index] = new Line(lineToChange.Command == Command.jmp ? Command.nop : Command.jmp, lineToChange.Parameter, lineToChange.Index);
            }

        }
    }
}
