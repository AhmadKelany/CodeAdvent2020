using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent.Code.CodeWars
{
    public class Logic
    {
        public static string Extract(int[] args)
        {
            string result = "";
            string range = "";
            for (int i = 1; i < args.Length; i++)
            {
                if (args[i] - args[i-1] == 1)
                {
                    if (range == "")
                    {
                        range = $"{args[i - 1]}-";
                    }
                }
                else
                {
                    if (range == "")
                    {
                        result += $"{args[i - 1]},";
                    }
                    else
                    {

                    }
                }
            }
        }
    }
}
