using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog
{
    public interface ILog
    {
        void LogDebug(string message);
        void LogException(Exception ex);
    }
}
