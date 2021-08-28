using Microsoft.Extensions.Logging;
using System;

namespace WithHighPerfLogging
{
    public static class AppLoggerTyped<TLogger> // why ?
    {
        private static readonly Action<ILogger<TLogger>, Exception> _sendFixedMessage = LoggerMessage.Define(LogLevel.Information, Events.Started, "Log message without args");
        private static readonly Action<ILogger<TLogger>, string, Exception> _sendMessage = LoggerMessage.Define<string>(LogLevel.Information, Events.Started, "Log message with string: {arg}");
        private static readonly Action<ILogger<TLogger>, string, int, Exception> _sendMessageWithInfo = LoggerMessage.Define<string, int>(LogLevel.Information, Events.Started, "Log message with args: {arg1} and {arg2}");

        public static void TraceMessage(ILogger<TLogger> logger) => AppLoggerTyped<TLogger>._sendFixedMessage(logger, null);
        public static void TraceMessage(ILogger<TLogger> logger, string message) => AppLoggerTyped<TLogger>._sendMessage(logger, message, null);
        public static void TraceMessage(ILogger<TLogger> logger, string message, int value)
        {
            if (logger.IsEnabled(LogLevel.Trace))
                AppLoggerTyped<TLogger>._sendMessageWithInfo(logger, message, value, null);
        }
        public static void DebugMessage(ILogger<TLogger> logger, string message)
        {
            if (logger.IsEnabled(LogLevel.Debug))
                AppLoggerTyped<TLogger>._sendMessage(logger, message, null);
        }
    }
}
