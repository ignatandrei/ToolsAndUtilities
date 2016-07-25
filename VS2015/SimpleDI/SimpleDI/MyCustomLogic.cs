using SimpleLog;

namespace SimpleDI
{
    public class MyCustomLogic
    {
        private ILog _logger;

        public MyCustomLogic(ILog logger)
        {
            _logger = logger;
        }

        public bool AffectsCalculus;

        public bool Calculus(int i, int j)
        {
            _logger.LogDebug("AffectCalculus=" + AffectsCalculus);


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
