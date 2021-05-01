using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeAdvent.Code._2020
{
    public class Day2
    {
        public static List<Input> GetInputs() => File.ReadAllLines("InputFiles/Day2.txt").Select(GetInput).ToList();

        public static Input GetInput(string line)
        {
            int dashIndex = line.IndexOf('-');
            int colonIndex = line.IndexOf(':');

            return new Input(int.Parse(line.Substring(0, dashIndex)),
                             int.Parse(line.Substring(dashIndex + 1, colonIndex - dashIndex - 2)),
                             line.Substring(colonIndex - 1).First(),
                             line.Substring(colonIndex + 1).Trim());
}

        public record Input(int Min, int Max, char letter, string password);


        public static bool Part1Valid(Input input)
        {
            int count = input.password.Count(c => c == input.letter);
            return count >= input.Min && count <= input.Max;
        }
        public static bool Part2Valid(Input input)
        {
            return input.password[input.Min-1] == input.letter ^ input.password[input.Max-1] == input.letter;
        }
        public static int Part1Count() => GetInputs().Count(Part1Valid);

        public static int Part2Count() => GetInputs().Count(Part2Valid);
    }
}
