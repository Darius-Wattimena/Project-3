using System;

namespace ProjectData.Util
{
    /// <summary>
    /// Small logging util to make writing to the console faster
    /// </summary>
    public class Log
    {
        private const string FATAL_PREFIX = "[FATAL] : ";
        private const string ErrorPrefix = "[ERROR] : ";
        private const string INFO_PREFIX = "[INFO] : ";
        private const string DEBUG_PREFIX = "[DEBUG] : ";

        public static void Logging(string message, LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Fatal:
                    Fatal(message);
                    break;
                case LogLevel.Error:
                    Error(message);
                    break;
                case LogLevel.Info:
                    Info(message);
                    break;
                case LogLevel.Debug:
                    Debug(message);
                    break;
            }
        }

        public static void Fatal(string message)
        {
            Console.WriteLine(FATAL_PREFIX + message);
        }

        public static void Error(string message)
        {
            Console.WriteLine(ErrorPrefix + message);
        }

        public static void Info(string message)
        {
            Console.WriteLine(INFO_PREFIX + message);
        }

        public static void Debug(string message)
        {
            Console.WriteLine(DEBUG_PREFIX + message);
        }
    }

    public enum LogLevel
    {
        Fatal,
        Error,
        Info,
        Debug
    }
}
