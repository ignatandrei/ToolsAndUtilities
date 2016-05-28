using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILMergeObj;

namespace ILMergeDOS
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = new MyClass();
            m.WebSite = "http://msprogrammer.serviciipeweb.ro/";
            Console.WriteLine(m.WebSite);
            Console.ReadLine();
        }
    }
}
