using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggerAspect;
using LoggerAspect.Nlog;

//using LoggerAspect.Nlog;

namespace InstrumentationPostSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggingAspect.Logger = new NLogLogger("AndreiIgnat");
            try
            {
                var p = new Person();
                p.DateOfBirth = DateTime.Now.AddYears(-10);
                p.Drink(10, 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR OCCURED " + ex.StackTrace);
            }
        }
    }
}
