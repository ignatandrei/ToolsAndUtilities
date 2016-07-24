using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComplicatedDll;

namespace EventsAndPlugins
{
    class PluginCalculus : IMyCalculusPluginInterface
    {
        public void IBeforeCalculus(MyCustomLogic custom)
        {
            custom.AffectsCalculus = true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var m = new MyCustomLogic();

            //m.MyCalculusPluginInterface=new PluginCalculus();
            //m.beforeCalculus += M_beforeCalculus;

            var result = m.Calculus(1, 1);
            Console.WriteLine(result);
        }

        private static void M_beforeCalculus(object sender, string e)
        {
            var m = sender as MyCustomLogic;
            m.AffectsCalculus = true;
        }
    }
}
