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
        public class Creature
        {
            static Dictionary<string, object> properties = new Dictionary<string, object>();
            public object this[string index]
            {
                get => properties[index];
                set => properties[index] = value;
            }
        }
            public static string StripComments(string text, string[] commentSymbols)
        {
            var lines = text.Split('\n');
            for(int s = 0;s<commentSymbols.Length;s++)
            {
                for (int l = 0; l < lines.Length; l++)
                {
                    int symbolIndex = lines[l].IndexOf(commentSymbols[s]);
                    if (symbolIndex > -1)
                    {
                        lines[l] = lines[l].Substring(0,symbolIndex);
                    }
                    lines[l] = lines[l].TrimEnd();
                }
            }

            return string.Join("\n",lines);

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
