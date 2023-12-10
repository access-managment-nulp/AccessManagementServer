namespace AccessManagementApp.Logger
{
    public class FileLogger : ILogger
    {
        private string filePath;
        public FileLogger(string filePath)
        {
            this.filePath = filePath;
        }

        public void Log(string message)
        {
            File.AppendAllText(filePath, message);
        }
    }
}
