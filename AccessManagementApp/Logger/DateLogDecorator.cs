namespace AccessManagementApp.Logger
{
    public class DateLogDecorator : ICustomLogger
    {
        private readonly ICustomLogger _logger;

        public DateLogDecorator(ICustomLogger logger)
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
