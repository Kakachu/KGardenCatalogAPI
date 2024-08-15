
namespace KGardenCatalogAPI.Logging
{
    public class CustomerLogger : ILogger
    {
        readonly string _loggerName;
        readonly CustomLoggerProviderConfiguration _loggerConfig;

        public CustomerLogger(string loggerName, CustomLoggerProviderConfiguration loggerConfig)
        {
            _loggerName = loggerName;
            _loggerConfig = loggerConfig;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == _loggerConfig.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            string message = $"{logLevel.ToString()} : {eventId.Id} - {formatter(state, exception)}";
            WriteTextFile(message);
        }

        private void WriteTextFile(string message)
        {
            string path = @"D:\Dev\Projects\ASP.NET 7.0\KGardenCatalogAPI\KGardenCatalogAPI\KGardenAPI_Log.txt";

            using (StreamWriter streamWriter = new StreamWriter(path, true))
            {
                try
                {
                    streamWriter.WriteLine(message);
                    streamWriter.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
