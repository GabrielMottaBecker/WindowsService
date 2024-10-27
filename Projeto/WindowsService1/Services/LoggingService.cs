using System;
using System.IO;

namespace WindowsService1.Services
{
    public sealed class LoggingService
    {
        private static readonly LoggingService _instance = new LoggingService();
        private const string LogFilePath = @"C:\Logs\service.log";

        private LoggingService() { }

        public static LoggingService Instance => _instance;

        public static void Log(string message)
        {
            var logMessage = $"{DateTime.Now}: {message}{Environment.NewLine}";
            File.AppendAllText(LogFilePath, logMessage);
        }
    }
}