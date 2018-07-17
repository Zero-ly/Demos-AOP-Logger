using MD.Logger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Autofac.Castle.Interceptor.Core
{
    public class LoggerConfig
    {
        #region Ctor
        public LoggerConfig() { }
        public LoggerConfig(string serviceUrl, ServiceType serviceType = ServiceType.Unknown, Developer developer = Developer.Undefined)
        {
            this.LogServiceUrl = serviceUrl;
            this.ServiceType = serviceType;
            this.Developer = developer;
        }
        #endregion

        public string LogServiceUrl { get; set; }
        public ServiceType ServiceType { get; set; }
        public Developer Developer { get; set; }
        public int RetryCount { get; set; }

        #region Extensions 
        // Ctor  !! 循环调用 GetSection和 LoggerConfig.
        //public LoggerConfig(string sectionKey, string jsonFilePath = "Config/appsettings.json")
        //{
        //    var config = GetSection(sectionKey, jsonFilePath);        //循环调用
        //    LogServiceUrl = config.LogServiceUrl;
        //    ServiceType = config.ServiceType;
        //    Developer = config.Developer;
        //}

        private static LoggerConfig GetSection(string key, string path)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(path);
            var configuration = builder.Build();

            var config = new LoggerConfig();
            configuration.GetSection(key).Bind(config);
            return config;
        }
        #endregion
    }
}
