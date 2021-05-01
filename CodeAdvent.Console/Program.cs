using CodeAdvent.Code;
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
                Screen.WriteLine("Please enter function data to solve, format: yyyy.d.i e.g.: 2015.1.1 will display 2015 day 1 part 1",
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
                //var type = Assembly.GetExecutingAssembly().GetType($"CodeAdvent.Code._{s[0]}.Day{s[1]})");  
                var a = Assembly.GetAssembly(typeof(CodeAdvent.Code._2015.Day1));
                var n = $"CodeAdvent.Code._{s[0]}.Day{s[1]}";
                var type = a.GetType(n);
                var ts = Assembly.GetExecutingAssembly().GetTypes();
                
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
