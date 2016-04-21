using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Logging
{
    class Program
    {
        private static Logger l;
        static void Main(string[] args)
        {
            l = LogManager.GetCurrentClassLogger();
            try
            {
                l.Log(LogLevel.Info, "in main");
                var textFile = ReadFile("a.txt");
                Console.WriteLine(textFile);
            }
            catch (Exception ex)
            {
                l.ErrorException("final error in main ",ex);
                
                Console.WriteLine("error happened");
            }
        }

        static string ReadFile(string nameFile)
        {
            l.Log(LogLevel.Info,nameFile);
            try
            {
                return File.ReadAllText(nameFile);
            }
            catch (Exception ex)
            {
                l.ErrorException("can not read file "+ nameFile,ex);
                    
                throw;
            }
            return Environment.CurrentDirectory;
        }
    }
}
