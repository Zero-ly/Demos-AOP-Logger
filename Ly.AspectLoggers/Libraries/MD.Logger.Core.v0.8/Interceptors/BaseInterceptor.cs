using Castle.DynamicProxy;
using Polly;
using System;

namespace MD.Logger.Core.Interceptors
{
    public abstract class BaseInterceptor : IInterceptor
    {
        #region Ctor
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="logServiceUrl">ELK日志服务连接地址(默认为 AppSettings["LogServiceConnStr"])</param>
        /// <param name="serviceType">MD服务枚举</param>
        /// <param name="developer">MD开发人员</param>
        public BaseInterceptor(string logServiceUrl = null, string accountId = null, ServiceType serviceType = ServiceType.Unknown, Developer developer = Developer.Undefined)
        {
            this.LogServiceUrl = logServiceUrl;//?? ConfigurationManager.AppSettings["LogServiceConnStr"];
            this.ServiceType = serviceType;
            this.AccountId = accountId;
            this.Developer = developer;
        }
        #endregion

        #region Fileds
        protected string LogServiceUrl { get; set; }
        protected string AccountId { get; set; }
        protected ServiceType ServiceType { get; set; }
        protected Developer Developer { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// 重复执行    失败则重复执行
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="action">Action</param>
        /// <param name="retryCount">重复次数</param>
        /// <returns></returns>
        protected virtual TResult Retry<TResult>(Func<TResult> action, int retryCount = 1)
        {
            return Policy
                .Handle<Exception>()
                .Retry(retryCount)
                .Execute(action);
        }

        /// <summary>
        /// 默认值     返回类型的默认值（但内部对象未实例化）
        /// </summary>
        /// <param name="returnType">Type</param>
        /// <returns>object</returns>
        protected virtual object Default(Type returnType)
        {
            if (returnType.FullName == "System.Void")
                return null;

            //ToImprove instance inner object

            return Activator.CreateInstance(returnType);
        }

        /// <summary>
        /// 格式化消息
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="args">方法参数值数组</param>
        /// <param name="methodInfo">方法信息</param>
        /// <returns></returns>
        protected virtual string MessageBuild(Exception ex)
        {
            return "";
        }

        /// <summary>
        /// 记录日志到 ELK中
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="args">方法参数值数组</param>
        /// <param name="methodInfo">方法信息</param>
        protected virtual void WriteLog(Exception ex, object[] args)
        {
            if (string.IsNullOrEmpty(this.LogServiceUrl))
                return;

            //ToImprove
            //  var methodFullname = string.Format($"{methodInfo.DeclaringType} {methodInfo} ");

            var msg = "";
            var client = LogClient.GetClient(LogServiceUrl);
            client?.Error(message: msg, action: "", accountId: this.AccountId,
                serviceType: this.ServiceType, developer: this.Developer,
                exception: ex);
        }
        #endregion

        public abstract void Intercept(IInvocation invocation);
    }
}
