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
        public record Line(Command Command , int Parameter , int Index);
        private List<int> AlteredIndexes = new List<int>();
        public static List<Line> GetLines() =>
            File.ReadAllLines("InputFiles/Day8.txt").
            Select((l,i) => new Line(Enum.Parse<Command>(l.Substring(0, 3)), int.Parse(l.Substring(3)) , i)).ToList();
        public static int Part1() => GetAccumulatorAndLastIndex(GetLines()).Accumulator;
        public static (int Accumulator,int LastIndex , bool ExitedProperly ) GetAccumulatorAndLastIndex(List<Line> lines)
        {
            int accumulator = 0;
            int nextIndex = 0;
            bool exitedProperly = false;
           List<int> processedLineIndexes = new List<int>();

            while (!processedLineIndexes.Contains(nextIndex))
            {
                if(nextIndex == lines.Count-1)
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
           
            return (accumulator , nextIndex , exitedProperly);


        }
        public static int Part2() {
            var lines = GetLines();
            int firstIndex = -1;
            while (true)
            {
                var lineToChange = lines.FirstOrDefault(l => l.Index > firstIndex && (l.Command == Command.jmp || l.Command == Command.nop));
                firstIndex = lineToChange.Index;
                lines[lineToChange.Index] = new Line(lineToChange.Command == Command.jmp ? Command.nop : Command.jmp, lineToChange.Parameter, lineToChange.Index);
                var result = GetAccumulatorAndLastIndex(lines);
                if(result.ExitedProperly)
                {
                    return result.Accumulator;
                }
                else
                {
                    lines[lineToChange.Index] = new Line(lineToChange.Command == Command.jmp ? Command.nop : Command.jmp, lineToChange.Parameter, lineToChange.Index);
                }
            }
            
        }
    }
}
