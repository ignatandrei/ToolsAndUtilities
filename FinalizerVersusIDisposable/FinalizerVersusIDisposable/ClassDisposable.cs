using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinalizerVersusIDisposable
{
    class classDisposable:IDisposable
    {
        private static int NumberInstance=0;
        public classDisposable()
        {
            //i++;  not atomic
            Interlocked.Add(ref NumberInstance, 1);
        }

        public int InstanceNumber
        {
            get { return NumberInstance; } 

        }

        public void Dispose()
        {
            Console.WriteLine("Dispose class disposable:"+NumberInstance);
        }
    }
}
