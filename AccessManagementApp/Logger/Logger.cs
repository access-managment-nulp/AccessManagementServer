namespace AccessManagementApp.Logger
{
    public static class Logger
    {
        public static readonly ILogger Instance = new DateLogDecorator(new FileLogger("test.log"));
    }
}
