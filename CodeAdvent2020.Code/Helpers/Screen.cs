using System;

namespace CodeAdvent2020.Code
{
    public static class Screen
    {
        public static void Write(string text, ConsoleColor consoleColor = ConsoleColor.White)
        {
            Console.ForegroundColor = consoleColor;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void WriteLine(string text = "", ConsoleColor consoleColor = ConsoleColor.White)
        {
            Write($"{text}\n", consoleColor);
        }
    }

}

