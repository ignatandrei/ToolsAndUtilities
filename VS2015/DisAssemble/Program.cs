using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disassemble
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string s = $"This thread is  {Thread.CurrentThread.ManagedThreadId} " +
                       $"user {Thread.CurrentPrincipal.Identity.Name}";
            Console.WriteLine(s);
        }
    }
}
