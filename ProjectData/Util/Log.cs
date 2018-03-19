using System;

namespace ProjectData.Util
{
    /// <summary>
    /// Small logging util to make writing to the console faster
    /// </summary>
    public class Log
    {
        private static readonly string FATAL_PREFIX = "[FATAL] : ";
        private static readonly string ERROR_PREFIX = "[ERROR] : ";
        private static readonly string INFO_PREFIX = "[INFO] : ";
        private static readonly string DEBUG_PREFIX = "[DEBUG] : ";

        public static void Logging(string message, LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.FATAL:
                    Fatal(message);
                    break;
                case LogLevel.ERROR:
                    Error(message);
                    break;
                case LogLevel.INFO:
                    Info(message);
                    break;
                case LogLevel.DEBUG:
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
            Console.WriteLine(ERROR_PREFIX + message);
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
        FATAL,
        ERROR,
        INFO,
        DEBUG
    }
}
