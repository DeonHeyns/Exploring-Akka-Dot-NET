using System;

namespace ExploringRemoting.Common
{
    public static class ColorConsole
    {
        public static void WriteLineGreen(string message)
        {
            var before = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = before;
        }

        public static void WriteLineYellow(string message)
        {
            var before = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ForegroundColor = before;
        }

        public static void WriteLineRed(string message)
        {
            var before = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = before;
        }

        public static void WriteLineCyan(string message)
        {
            var before = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ForegroundColor = before;
        }

        public static void WriteLineGray(string message)
        {
            var before = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(message);
            Console.ForegroundColor = before;
        }

        public static void WriteLineMagenta(string message)
        {
            var before = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(message);
            Console.ForegroundColor = before;
        }
    }

}
