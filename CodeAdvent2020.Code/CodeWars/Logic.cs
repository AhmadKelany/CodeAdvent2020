using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeAdvent.Code.CodeWars
{
    public class Logic
    {
        public static string StripComments(string text, string[] commentSymbols)
        {
            for(int i = 0; i < commentSymbols.Length; i++)
            {
                commentSymbols[i] = commentSymbols[i].Replace("$", "×");
            }
            text = text.Replace("$", "×");
            string pattern = $" +({string.Join(@"|" , commentSymbols)})[ |\\w]+";
            var matches = Regex.Matches(text, pattern);
            foreach (var match in matches)
            {
                text = text.Replace(match.ToString(), "");
            }
            return text;
        }

        public static string Extract(int[] args)
        {
            string result = "";
            int index = 0;
            while (index < args.Length)
            {
                int lastIndex = index + 1;
                int firstInRange = args[index];
                List<int> range = new List<int> { firstInRange };
                while (lastIndex < args.Length)
                {
                    if (args[lastIndex] - args[lastIndex - 1] == 1)
                    {
                        range.Add(args[lastIndex]);
                        lastIndex++;
                    }
                    else
                    {
                        index = lastIndex;
                        break;
                    }
                }
                if (range.Count < 3)
                {
                    foreach (var item in range)
                    {
                        result += $"{item},";
                    }
                }
                else
                {
                    result += $"{range.First()}-{range.Last()},";
                }
                index = Array.IndexOf(args, range.Last()) + 1;
            }
            return result.Trim(',');
        }
    }
}
