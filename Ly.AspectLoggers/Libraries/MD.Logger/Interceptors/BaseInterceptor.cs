using Polly;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MD.Logger.Interceptors
{
    public class BaseInterceptor
    {
        protected virtual object Default(Type returnType)
        {
            if (returnType.FullName == "System.Void")
                return null;

            return Activator.CreateInstance(returnType);
        }

        protected virtual void WriteLog(Exception ex, object[] args, MethodBase methodInfo)
        {
            #region 获取拼接日志内容

            var parameters = methodInfo.GetParameters();
            var sb1 = new StringBuilder();

            //Method's Name = methodInfo.DeclaringType.ToString() + " " + methodInfo.ToString()

            sb1.Append($"Method:[{methodInfo.Name}]|Params:[");
            for (var i = 0; i < parameters.Length; i++)
            {
                sb1.Append(args[i] != null ? $"{parameters[i].Name}:{args[i]};" : $"{parameters[i].Name}:null;");
            }

            var sb2 = new StringBuilder();
            sb2.Append($"]|ExceptionMessage:{ex.Message} ");

            var logInfo = sb1.ToString().TrimEnd(';') + sb2;
            #endregion

            //todo write
            //var serviceUrl = ConfigurationManager.AppSettings["LogServiceConnStr"];
            ////serviceUrl = "172.17.30.234:5051"
            //var client = LogClient.GetClient(serviceUrl);
            //client.Error(logInfo, methodInfo.Name);
        }

        protected virtual TResult Retry<TResult>(Func<TResult> action)
        {
            return Policy
                .Handle<Exception>()
                .Retry(1)
                .Execute(action);
        }
    }
}
