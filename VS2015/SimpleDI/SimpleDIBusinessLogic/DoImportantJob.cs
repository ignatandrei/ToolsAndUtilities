using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleDI;
using SimpleLog;
using StructureMap;

namespace SimpleDIBusinessLogic
{
    public class DoImportantJob
    {
        private Container _container;
        public DoImportantJob(Container container)
        {
            _container = container;
        }

        public void ImportantJob()
        {
            //var m = new MyCustomLogic(new ConsoleLogger());
            var m = new MyCustomLogic(_container.GetInstance<ILog>()); 
            Console.WriteLine(m.Calculus(1, 1));

        }
    }
}
