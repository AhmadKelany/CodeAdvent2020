using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2020.Code._2020
{
    public class Day9
    {
        public static List<long> GetData() =>
            File.ReadAllLines("InputFiles/Day9.txt").
            Select(long.Parse).ToList();

        public static bool IsValid(long number , IEnumerable<long> previousNumbers)
        {
            return (from x in previousNumbers
                    from y in previousNumbers
                    where x != y && number == x + y
                    select x).Any();
        }

        public static long Part1()
        {
            var data = GetData();
            int preamble = 25;
            return data.
                Where((n, i) => i>=preamble && !IsValid(n, data.Skip(i - preamble ).Take(preamble))).FirstOrDefault();
        }

        public static long Part2()
        {
            var data = GetData();
            long part1Number = Part1();
            int startIndex = 0;
            while (true)
            {
                List<long> results = new List<long>();
                for (int i = startIndex; i < data.Count; i++)
                {
                    results.Add(data[i]);
                    if (results.Sum() == part1Number)
                    {
                        break;
                    }
                    else if(results.Sum() > part1Number)
                    {
                        results.Clear();
                        startIndex++;
                        break;
                    }

                }
                if (results.Any())
                {
                    return results.Min() + results.Max();
                }

            }

        }
    }
}
