using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalizerVersusIDisposable
{
    class classFinalize
    {

         ~classFinalize()
        {
            Console.WriteLine("from class finalize");
        }
    }
}
