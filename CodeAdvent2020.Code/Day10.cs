using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2020.Code
{
    public class Day10
    {
        public static List<int> GetData() =>
                   File.ReadAllLines("InputFiles/Day10.txt").
                   Select(int.Parse).ToList();

        public static int Part1()
        {
            var chargers = GetData();
            chargers.Add(0);
            chargers = chargers.OrderBy(c => c).ToList();
            int onesCount = 0;
            int threesCount = 1;
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

    }
}
