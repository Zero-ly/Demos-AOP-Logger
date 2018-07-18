using Castle.DynamicProxy;
using MD.Logger;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Text;

namespace Autofac.Castle.Interceptor.Core
{
    public class InterceptLogger : IInterceptLogger
    {
        #region Fields
        private readonly string AccountId;
        public string LogServiceUrl { get; set; }
        public ServiceType ServiceType { get; set; }
        public Developer Developer { get; set; }
        public int RetryCount { get; set; }
        #endregion

        #region Ctor
        public InterceptLogger(string logServiceUrl = null, string accountId = null, ServiceType serviceType = ServiceType.Unknown, Developer developer = Developer.Undefined)
        {


            this.LogServiceUrl = logServiceUrl ?? DefaultLogServiceUrl();
            this.AccountId = accountId;               //？？ accountid 应在write时提供
            this.ServiceType = serviceType;
            this.Developer = developer;
        }
        #endregion

        #region Utilities
        protected string DefaultLogServiceUrl()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("Config/appsettings.json");
            var config = builder.Build();

            return config?.GetSection("LogServiceConnStr")?.Value;
        }
        protected string MessageBuild(IInvocation invocation, Exception ex)
        {
            var methodInfo = invocation.Method;

            var sb1 = new StringBuilder();
            sb1.Append($"Method:[{methodInfo.Name}]|Params:[");

            var parameters = methodInfo.GetParameters();
            var args = invocation.Arguments;
            for (var i = 0; i < parameters.Length; i++)
            {
                sb1.Append(args[i] != null
                    ? $"{parameters[i].Name}:{args[i]};"
                    : $"{parameters[i].Name}:null;");
            }

            var sb2 = new StringBuilder();
            sb2.Append($"]|ExceptionMessage:{ex.Message} ");

            var message = sb1.ToString().TrimEnd(';') + sb2;
            return message;
        }
        #endregion

        public virtual void Write(IInvocation invocation, Exception ex)
        {
            if (string.IsNullOrEmpty(this.LogServiceUrl))
                return;

            var msg = MessageBuild(invocation, ex);
            var client = LogClient.GetClient(LogServiceUrl);
            client?.Error(message: msg, action: invocation.Method.Name,
                accountId: this.AccountId,
                serviceType: this.ServiceType, developer: this.Developer,
                exception: ex);
        }
    }
}
