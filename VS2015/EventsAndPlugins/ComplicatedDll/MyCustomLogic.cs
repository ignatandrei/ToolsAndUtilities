using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplicatedDll
{
    public class MyCustomLogic
    {

        public bool AffectsCalculus;
        public event EventHandler<string> beforeCalculus;
        public IMyCalculusPluginInterface MyCalculusPluginInterface;
        public bool Calculus(int i, int j)
        {
            if (beforeCalculus != null)
            {
                beforeCalculus(this, "my custom data");
            }

            if (MyCalculusPluginInterface != null)
            {
                MyCalculusPluginInterface.IBeforeCalculus(this);
            }

            if (AffectsCalculus)
            {
                return i == j;
            }
            else
            {
                return i - 1 == j + 1;
            }

        }
    }
}