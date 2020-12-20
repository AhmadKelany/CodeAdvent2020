using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2020.Code
{
    public class Day10
    {
        public static ImmutableList<int> GetData()
        {
            var chargers = File.ReadAllLines("InputFiles/Day10.txt").Select(int.Parse).OrderBy(i => i);

            return ImmutableList.Create(0).AddRange(chargers).Add(chargers.Last() + 3);
        }

        public static int Part1OtherSolution()
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

        public static long Part2()
        {
            var chargers = GetData();
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
