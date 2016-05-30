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
        /// <summary>
        /// References:
        /// http://research.microsoft.com/en-us/people/mbarnett/ilmerge.aspx
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var m = new MyClass();
            m.WebSite = "http://msprogrammer.serviciipeweb.ro/";
            Console.WriteLine(m.WebSite);
            Console.ReadLine();
        }
    }
}
