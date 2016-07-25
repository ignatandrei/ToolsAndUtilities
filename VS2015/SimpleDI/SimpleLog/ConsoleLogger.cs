using System;

namespace SimpleLog
{
    public class ConsoleLogger : ILog
    {
        public void LogDebug(string message)
        {
            var cc = Console.ForegroundColor;
            Console.ForegroundColor= ConsoleColor.DarkYellow;
            Console.WriteLine(message);
            Console.ForegroundColor = cc;
        }

        public void LogException(Exception ex)
        {
            var cc = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ForegroundColor = cc;

        }
    }
}