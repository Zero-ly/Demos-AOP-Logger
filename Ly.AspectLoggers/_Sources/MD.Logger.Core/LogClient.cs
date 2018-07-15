using Grpc.Core;
using System.Collections.Concurrent;
using static MD.Logger.LogService;

namespace MD.Logger.Core
{
    public class LogClient
    {
        private static readonly ConcurrentDictionary<string, LogServiceClient> ClientCache = new ConcurrentDictionary<string, LogServiceClient>();
        private static object syncObj = new object();

        /// <summary>
        /// 获取一个Client实例（单例）
        /// </summary>
        /// <param name="serviceUrl"></param>
        /// <returns></returns>
        public static LogServiceClient GetClient(string serviceUrl)
        {
            if (!string.IsNullOrEmpty(serviceUrl))
            {
                if (!ClientCache.ContainsKey(serviceUrl))
                {
                    lock (syncObj)
                    {
                        if (!ClientCache.ContainsKey(serviceUrl))
                        {
                            var channel = new Channel(serviceUrl, ChannelCredentials.Insecure);
                            ClientCache[serviceUrl] = new LogServiceClient(channel);
                        }
                    }
                }
                return ClientCache[serviceUrl];
            }
            return null;
        }
    }
}
