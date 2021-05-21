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
            while (true)
            {
                var hex = MD5.Create();
            }
        }
    }
}
