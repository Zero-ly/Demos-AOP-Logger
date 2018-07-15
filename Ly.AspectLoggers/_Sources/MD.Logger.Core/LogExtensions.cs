using MD.Logger;
using System;
using System.Collections.Generic;
using System.Net;
using static MD.Logger.LogService;

namespace MD.Logger.Core
{
    public static class LogExtensions
    {
        #region Logger Utilities
        public static void WriteLogAsync(this LogServiceClient client, string message, DateTime? timeStamp = null
            , LogLevel logLevel = LogLevel.Error
            , string action = null, string accountId = null
            , string hostName = null, string clientIp = null
            , ServiceType serviceType = ServiceType.Unknown, Developer developer = Developer.Undefined
            , Exception exception = null, IDictionary<string, string> extras = null)
        {

            client.WriteLogAsync(message, (timeStamp?.ToTickTimeStamp() ?? DateTime.Now.ToTickTimeStamp())
                , logLevel
                , action, accountId, hostName, clientIp, serviceType, developer, exception, extras);
        }

        public static void WriteLogAsync(this LogServiceClient client, string message, long timeStamp
            , LogLevel logLevel = LogLevel.Error
            , string action = null, string accountId = null
            , string hostName = null, string clientIp = null
            , ServiceType serviceType = ServiceType.Unknown, Developer developer = Developer.Undefined
            , Exception exception = null, IDictionary<string, string> extras = null)
        {
            var mingLog = new MingLog()
            {
                Message = message,
                TimeStamp = timeStamp,

                HostName = hostName,
                ClientIp = clientIp,
                ServiceType = serviceType,
                Developer = developer,
                Action = action,
                Level = logLevel,
                AccountId = accountId,
                Stack = exception?.StackTrace,
            };

            if (extras != null)
                foreach (var i in extras)
                {
                    mingLog.Extras.Add(extras);
                }

            client.WriteLogAsync(mingLog);
        }
        #endregion

        #region Helper Utilities
        private static long ToTickTimeStamp(this DateTime _this)
        {
            var time = _this.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return time.Ticks;
        }
        private static string GetHostName()
        {
            return Dns.GetHostName();
        }

        private static string GetClientIp()
        {
            return null; // Dns.GetHostAddresses(Dns.GetHostName())[0].ToString();
        }
        #endregion

        #region Error | Debug | Info | Warning
        public static void Error(this LogServiceClient client, string message
            , string action = null, string accountId = null
            , ServiceType serviceType = ServiceType.Unknown, Developer developer = Developer.Undefined
            , Exception exception = null, IDictionary<string, string> extras = null)
        {
            //Default logLevel,timeStamp,hostName,clientIp
            var logLevel = LogLevel.Error;
            var timeStamp = DateTime.Now.ToTickTimeStamp();
            var hostName = GetHostName();
            var clientIp = GetClientIp();

            client.WriteLogAsync(message, timeStamp, logLevel
                , action, accountId, hostName, clientIp, serviceType, developer, exception, extras);
        }

        public static void FatalError(this LogServiceClient client, string message
            , string action = null, string accountId = null
            , ServiceType serviceType = ServiceType.Unknown, Developer developer = Developer.Undefined
            , Exception exception = null, IDictionary<string, string> extras = null)
        {
            //Default logLevel,timeStamp,hostName,clientIp
            var logLevel = LogLevel.Fatal;
            var timeStamp = DateTime.Now.ToTickTimeStamp();
            var hostName = GetHostName();
            var clientIp = GetClientIp();

            client.WriteLogAsync(message, timeStamp, logLevel
                , action, accountId, hostName, clientIp, serviceType, developer, exception, extras);
        }

        public static void Info(this LogServiceClient client, string message
            , string action = null, string accountId = null
            , ServiceType serviceType = ServiceType.Unknown, Developer developer = Developer.Undefined
            , Exception exception = null, IDictionary<string, string> extras = null)
        {
            //Default logLevel,timeStamp,hostName,clientIp
            var logLevel = LogLevel.Info;
            var timeStamp = DateTime.Now.ToTickTimeStamp();
            var hostName = GetHostName();
            var clientIp = GetClientIp();

            client.WriteLogAsync(message, timeStamp, logLevel
                , action, accountId, hostName, clientIp, serviceType, developer, exception, extras);
        }

        public static void Debug(this LogServiceClient client, string message
            , string action = null, string accountId = null
            , ServiceType serviceType = ServiceType.Unknown, Developer developer = Developer.Undefined
            , Exception exception = null, IDictionary<string, string> extras = null)
        {
            //Default logLevel,timeStamp,hostName,clientIp
            var logLevel = LogLevel.Debug;
            var timeStamp = DateTime.Now.ToTickTimeStamp();
            var hostName = GetHostName();
            var clientIp = GetClientIp();

            client.WriteLogAsync(message, timeStamp, logLevel
                , action, accountId, hostName, clientIp, serviceType, developer, exception, extras);
        }

        public static void Warning(this LogServiceClient client, string message
            , string action = null, string accountId = null
            , ServiceType serviceType = ServiceType.Unknown, Developer developer = Developer.Undefined
            , Exception exception = null, IDictionary<string, string> extras = null)
        {
            //Default logLevel,timeStamp,hostName,clientIp
            var logLevel = LogLevel.Warn;
            var timeStamp = DateTime.Now.ToTickTimeStamp();
            var hostName = GetHostName();
            var clientIp = GetClientIp();

            client.WriteLogAsync(message, timeStamp, logLevel
                , action, accountId, hostName, clientIp, serviceType, developer, exception, extras);
        }
        #endregion

        #region Loggers
        private static void WriteAsync(this LogServiceClient client, string message)
        {
            // Todo
        }
        #endregion
    }
}
