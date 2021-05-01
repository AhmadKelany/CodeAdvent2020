using CodeAdvent2020.Code;
using System;
using System.Reflection;

namespace CodeAdvent.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Screen.WriteLine("Please enter function data to solve, format: yyyy.d.i e.g.: 2015.1.1 will display 2015 day 1 part 1", ConsoleColor.Magenta);
                var input = Console.ReadLine();
                InvokeMethod(input);
            }
        }

        private static void InvokeMethod(string input)
        {
            try
            {
                var s = input.Split(".");
                var type = Assembly.GetExecutingAssembly().GetType($"CodeAdvent2020.Code._{s[0]}.Day{s[1]})");
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
