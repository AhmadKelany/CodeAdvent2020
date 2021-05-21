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
        static string input = "abcdef";
        static int GetRequiredInt(string input , int zerosCount)
        {
            string match = new string('0', zerosCount);
            int i = 0;
            while (true)
            {
                byte[] dataToHashBytes = System.Text.Encoding.ASCII.GetBytes($"input{i++}");
                using (var md5 = MD5.Create())
                {
                    var hashed = md5.ComputeHash(dataToHashBytes);
                    string hex = BitConverter.ToString(hashed).Replace("-", "");
                    if (hex.StartsWith(match)) return i;
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
