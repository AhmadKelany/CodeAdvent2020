using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent.Code._2015
{
    public class Day7
    {
        public static List<string> GetInput() => File.ReadAllLines("2015/InputFiles/Day7.txt").ToList();
        static bool IsInt(string s)
        {
            return int.TryParse(s, out _);
        }
        public static void ProcessData(string s, Dictionary<string, int> data)
        {
            var a = s.Split(' ');

            switch (a.Length)
            {
                case 3: // assignment, to a number or to another variable
                    if (IsInt(a[0]) || data.ContainsKey(a[0]))
                    {
                        data[a[2]] = data.ContainsKey(a[0]) ? data[a[0]] : int.Parse(a[0]);
                    }
                    break;
                case 4: // not

                    data[a[3]] = UInt16.MaxValue - int.Parse(a[1]);
                    break;
                case 5: // and, or, lshift, rshift
                    int o1 = data.ContainsKey(a[0]) ? data[a[0]] : int.Parse(a[0]);
                    int o2 = data.ContainsKey(a[2]) ? data[a[2]] : int.Parse(a[2]);
                    switch (a[1])
                    {
                        case "AND":
                            data[a[4]] = o1 & o2;
                            break;
                        case "OR":
                            data[a[4]] = o1 | o2;
                            break;
                        case "LSHIFT":
                            data[a[4]] = o1 >> o2;
                            break;
                        case "RSHIFT":
                            data[a[4]] = o1 << o2;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

    }

    public static int Part1()
    {
        var d = new Dictionary<string, int>();
        foreach (var item in GetInput())
        {
            ProcessData(item, d);
        }
        var result = d["a"];
        Screen.WriteLine($"Part 1 result = {result}");
        return result;
    }
}
}
