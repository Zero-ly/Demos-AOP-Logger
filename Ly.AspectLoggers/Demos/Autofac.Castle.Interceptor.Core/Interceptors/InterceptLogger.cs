using Castle.DynamicProxy;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace MD.Logger.Interceptors
{
    public class InterceptLogger : IInterceptLogger
    {
        #region Fields
        public string LogServiceUrl { get; set; }
        #endregion

        #region Ctor
        public InterceptLogger(string logServiceUrl = null)
        {
            this.LogServiceUrl = logServiceUrl ?? DefaultLogServiceUrl();
        }
        #endregion

        protected string DefaultLogServiceUrl()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("Config/appsettings.json");
            var config = builder.Build();

            return config?.GetSection("LogServiceConnStr")?.Value;
        }

        public virtual void Write(IInvocation invocation, Exception ex)
        {
            if (string.IsNullOrEmpty(this.LogServiceUrl))
                return;


            Debug.WriteLine("InterceptLogger Write");
            Console.WriteLine("InterceptLogger Write");
        }
    }
}
