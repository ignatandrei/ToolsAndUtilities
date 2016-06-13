using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyConstructorReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var p=new Person();
            p.Name = "Andrei Ignat";
            p.WebSite = "http://msprogrammer.serviciipeweb.ro/";

            var newPerson=new Person(p);
            Console.WriteLine(newPerson.WebSite);

        }
    }
}
