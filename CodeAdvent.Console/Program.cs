using CodeAdvent.Code;
using System;
using System.Reflection;

namespace CodeAdvent.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            OtherCode.ShowLCSArray(); return;
            while(true)
            {
                Screen.WriteLine("Please enter function data to solve,\nformat: yyyy.d.i\ne.g.: 2015.1.1 will display 2015 day 1 part 1",
                    ConsoleColor.Yellow);
                
                var input = Console.ReadLine();
                InvokeMethod(input);
            }
        }

        private static void InvokeMethod(string input)
        {
            try
            {
                var s = input.Split(".");
                var a = Assembly.GetAssembly(typeof(CodeAdvent.Code._2021.Day1));
                var n = $"CodeAdvent.Code._{s[0]}.Day{s[1]}";
                var type = a.GetType(n);
                var m = type.GetMethod($"Part{s[2]}");
                m.Invoke(null, null);

            }
            catch (Exception ex)
            {
                Screen.WriteLine("An Error happend\n" + ex.Message, ConsoleColor.Red);
            }
           
        }
    }
}
