namespace KGardenCatalogAPI.Logging
{
    public class CustomLoggerProviderConfiguration
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Warning; //Defines the minimun level of log to be logged, with the default LogLevel.Warning
        public int EventId { get; set; } = 0; //Defines the event log Id, with the default value zero
    }
}
