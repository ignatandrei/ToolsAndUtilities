using System;

namespace SimpleLog
{
    public class NullLogger : ILog
    {
        public void LogDebug(string message)
        {
            
        }

        public void LogException(Exception ex)
        {
            
        }
    }
}