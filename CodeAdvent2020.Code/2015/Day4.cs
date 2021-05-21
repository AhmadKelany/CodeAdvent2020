using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CodeAdvent.Code._2015
{
    public class Day4
    {
        static string input = "iwrupvqb";
        static int GetRequiredInt(string input, int zerosCount)
        {
            string match = new string('0', zerosCount);
            int i = 0;
            using (var md5 = MD5.Create())
            {
                while (true)
                {

                    var hashBytes = md5.ComputeHash(Encoding.ASCII.GetBytes($"{input}{i}"));
                    var hash = string.Join("", hashBytes.Select(b => b.ToString("x2")));
                    if (hash.StartsWith(match)) return i;
                    i += 1;
                }
            }
        }
        public static int Part1()
        {
            int result = GetRequiredInt(input, 5);
            Screen.WriteLine($"Result = {result}", ConsoleColor.Green);
            return result;
        }
        public static int Part2()
        {
            int result = GetRequiredInt(input, 6);
            Screen.WriteLine($"Result = {result}", ConsoleColor.Green);
            return result;
        }

    }
}
