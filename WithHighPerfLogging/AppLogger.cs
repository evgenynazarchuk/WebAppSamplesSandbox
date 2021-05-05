using System;
using Microsoft.Extensions.Logging;

namespace WithHighPerfLogging
{
    public static class AppLogger
    {
        private static readonly Action<ILogger, Exception> _sendFixedMessage = LoggerMessage.Define(LogLevel.Information, Events.Started, "Log message without args");
        private static readonly Action<ILogger, string, Exception> _sendMessage = LoggerMessage.Define<string>(LogLevel.Information, Events.Started, "Log message with string: {arg}");
        private static readonly Action<ILogger, string, int, Exception> _sendMessageWithInfo = LoggerMessage.Define<string, int>(LogLevel.Information, Events.Started, "Log message with args: {arg1} and {arg2}");

        public static void TraceMessage(ILogger logger) => AppLogger._sendFixedMessage(logger, null);
        public static void TraceMessage(ILogger logger, string message) => AppLogger._sendMessage(logger, message, null);
        public static void TraceMessage(ILogger logger, string message, int value)
        {
            if (logger.IsEnabled(LogLevel.Trace))
                AppLogger._sendMessageWithInfo(logger, message, value, null);
        }
        public static void DebugMessage(ILogger logger, string message)
        {
            if (logger.IsEnabled(LogLevel.Debug))
                AppLogger._sendMessage(logger, message, null);
        }
    }
}
