
using Newtonsoft.Json.Linq;

namespace AccessManagementApp.Logger
{
    public class SingletonLogger : ICustomLogger
    {
        private SingletonLogger () { }

        private static ICustomLogger _instance;

        private static readonly object _lock = new object();

        public static ICustomLogger GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DateLogDecorator(new FileLogger("../logs.log"));
                    }
                }
            }
            return _instance;
        }

        public void Log(string message)
        {
            _instance.Log(message);
        }
    }
}
