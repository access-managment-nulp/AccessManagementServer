namespace AccessManagementApp.Logger
{
    public class DateLogDecorator : ILogger
    {
        private readonly ILogger _logger;

        public DateLogDecorator(ILogger logger)
        {
            _logger = logger;
        }
        public void Log(string message)
        {
            var datedMessage = $"{DateTime.Now:O}: {message}";
            
            _logger.Log(datedMessage);
        }
    }
}
