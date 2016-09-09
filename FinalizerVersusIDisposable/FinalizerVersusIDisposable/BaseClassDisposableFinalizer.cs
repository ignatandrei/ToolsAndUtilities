using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinalizerVersusIDisposable
{
    /// <summary>
    /// https://msdn.microsoft.com/en-us/library/fs2xkftw(v=vs.110).aspx
    /// </summary>
    class BaseClassDisposableFinalizer : IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing, [CallerMemberName] string memberName = "")
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }
            Console.WriteLine("this is Disposable in class BaseClassDisposableFinalizer called from: " + memberName);
            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ~BaseClassDisposableFinalizer ()
        {
            Dispose(false);
        }
    }
}
