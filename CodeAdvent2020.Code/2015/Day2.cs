using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CodeAdvent.Code._2015
{
    public class Day2
    {
        static (int h , int w , int l) GetBox(string input)
        {
            var s = input.Split('x').Select(int.Parse).ToList();
            return (s[0] , s[1] ,s[2]);
        }
        static int GetArea((int h, int w, int l) box)
        {
            return 2 * box.l * box.w + 2 * box.w * box.h + 2 * box.h * box.l;
        }
        
        static int GetSlack((int h, int w, int l) box)
        {
            return Math.Min(box.h * box.w, Math.Min(box.l * box.h, box.w * box.l));
        }

        static int GetRibbonArea((int h, int w, int l) box)
        {
            int l1 = Math.Min(box.h, box.l);
            int l2 = l1 == box.h ? Math.Min(box.l, box.w) : Math.Min(box.h, box.w);
            return 2 * l1 + 2 * l2 + box.h * box.l * box.w;
        }
        static List<string> GetInput() => File.ReadAllLines("2015/InputFiles/Day2.txt").ToList();
        public static int Part1()
        {
            var result = GetInput().Select(GetBox).Select(b => GetArea(b) + GetSlack(b)).Sum();
            Screen.WriteLine($"Result = {result}");
            return result;
            
        }
        public static int Part2()
        {
            var result = GetInput().Select(GetBox).Select(GetRibbonArea).Sum();
            Screen.WriteLine($"Result = {result}");
            return result;
        }

    }
}
