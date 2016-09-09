using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FinalizerVersusIDisposable
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var cd1 = new classDisposable())
            {
                Console.WriteLine("class disposable:"+ cd1.InstanceNumber);
            }
            var cf = new classFinalize();
            var cd2=new classDisposable();
            Console.WriteLine("class disposable:" + cd2.InstanceNumber);
            Console.ReadKey();

            using (var bcd = new BaseClassDisposableFinalizer())
            {
                
            } 
            var bcd1=new BaseClassDisposableFinalizer();
            Console.ReadKey();



        }
    }
}
