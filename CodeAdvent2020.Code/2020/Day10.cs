using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2020.Code._2020
{
    public class Day10
    {
        public static ImmutableList<int> GetData()
        {
            var chargers = File.ReadAllLines("InputFiles/Day10.txt").Select(int.Parse).OrderBy(i => i);

            return ImmutableList.Create(0).AddRange(chargers).Add(chargers.Last() + 3);
        }

        public static int Part1_OtherSolution()
        {
            var chargers = GetData();
            var window = chargers.Skip(1).Zip(chargers).Select(p => (current: p.First, previous: p.Second));
            return window.Count(p => p.current - p.previous == 1) * window.Count(p => p.current - p.previous == 3);
        }

        public static int Part1()
        {
            var chargers = GetData();
            int onesCount = 0;
            int threesCount = 0;
            for (int i = 0; i < chargers.Count-1; i++)
            {
                if (chargers[i+1] - chargers[i] == 1)
                {
                    onesCount++;
                }
                else if (chargers[i+1] - chargers[i] == 3)
                {
                    threesCount++;
                }

            }
            return onesCount * threesCount;
        }


        public static Dictionary<int , long> MappedIndexes = new Dictionary<int, long>();
        public static long WaysCount(ImmutableList<int> input , int index)
        {
            if (MappedIndexes.ContainsKey(index)) return MappedIndexes[index];
            if (index == input.Count - 1) return 1;
            long total = 0;
            if (index+1 < input.Count && input[index+1] - input[index] <= 3) 
            {
                total += WaysCount(input, index + 1);
            }
            if (index+2 < input.Count && input[index+2] - input[index] <= 3) 
            {
                total += WaysCount(input, index + 2);
            }
            if (index + 3 < input.Count && input[index + 3] - input[index] <= 3)
            {
                total += WaysCount(input, index + 3);
            }


            MappedIndexes[index] = total;
            return total;
        }
        public static long Part2()
        {

            var chargers = GetData();

            return WaysCount(chargers, 0);




            var (a, b, c) = (1L, 0L, 0L);
            for (var i = chargers.Count - 2; i >= 0; i--)
            {
                var s =
                    (i + 1 < chargers.Count && chargers[i + 1] - chargers[i] <= 3 ? a : 0) +
                    (i + 2 < chargers.Count && chargers[i + 2] - chargers[i] <= 3 ? b : 0) +
                    (i + 3 < chargers.Count && chargers[i + 3] - chargers[i] <= 3 ? c : 0);
                (a, b, c) = (s, a, b);
            }
            return a;
        }
    }
}
