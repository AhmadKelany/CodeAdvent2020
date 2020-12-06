using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeAdvent2020.Code
{
    public class Day1
    {
        public static List<int> GetInputs() => File.ReadAllLines("InputFiles/Day1.txt").Select(int.Parse).ToList();
        
        public static int Part1() 
        {
            var inputs = GetInputs();
            return (from x in inputs
                    from y in inputs.Skip(1)
                    where x + y == 2020
                    select x * y).FirstOrDefault();
        }
        public static int Part2() 
        {
            var inputs = GetInputs();
            return (from x in inputs
                    from y in inputs.Skip(1)
                    from z in inputs.Skip(2)
                    where x + y + z == 2020
                    select x * y * z).FirstOrDefault();
        }
    }
}
