﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeAdvent.Code._2020
{
    public class Day1
    {
        public static List<int> GetInputs() => File.ReadAllLines("2020/InputFiles/Day1.txt").Select(int.Parse).ToList();
        
        public static int Part1() 
        {
            var inputs = GetInputs();
            var result =  (from x in inputs
                    from y in inputs.Skip(1)
                    where x + y == 2020
                    select x * y).FirstOrDefault();

            Screen.WriteLine($"result = {result}" , ConsoleColor.Green);
            return result;
        }
        public static int Part2() 
        {
            var inputs = GetInputs();
            var result = (from x in inputs
                    from y in inputs.Skip(1)
                    from z in inputs.Skip(2)
                    where x + y + z == 2020
                    select x * y * z).FirstOrDefault();

            Screen.WriteLine($"result = {result}", ConsoleColor.Green);
            return result;

        }
    }
}
