using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleDI;
using SimpleDIBusinessLogic;
using SimpleLog;
using StructureMap;

namespace SimpleDIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(_ =>
            {
                _.For<ILog>().Use<ConsoleLogger>();
                                
            });
            var d = new DoImportantJob(container);
            d.ImportantJob();
        }
    }
}
