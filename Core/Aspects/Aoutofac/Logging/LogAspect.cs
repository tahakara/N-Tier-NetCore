using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Utilities.Interseptors;
using Core.Utilities.Messages;

namespace Core.Aspects.Aoutofac.Logging
{
    public class LogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;

        public LogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new System.Exception(AspectMessages.WrongLoggerType);
            }

            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }

        private T GetLogDetail<T>(IInvocation invocation, Exception exception = null) where T : LogDetail, new()
        {
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }

            var logDetail = new T
            {
                MethodName = string.Concat(invocation.Method.ReflectedType.Name, ".", invocation.Method.Name),
                LogParameters = logParameters
            };

            if (logDetail is LogDetailWithException logDetailWithException && exception != null)
            {
                logDetailWithException.ExceptionMessage = exception.Message;
            }

            return logDetail;
        }
        
        protected override void OnBefore(IInvocation invocation)
        {
            var logDetail = GetLogDetail<LogDetail>(invocation);
            var logdetailstring = logDetail.ToString();
            var a = string.Format(AspectMessages.LogBefore, logdetailstring);
            _loggerServiceBase.Info(a);
        }

        protected override void OnAfter(IInvocation invocation)
        {
            _loggerServiceBase.Info(string.Format(AspectMessages.LogAfter, GetLogDetail<LogDetail>(invocation)));
        }

        protected override void OnException(IInvocation invocation, Exception e)
        {
            _loggerServiceBase.Error(string.Format(AspectMessages.LogAfter, GetLogDetail<LogDetailWithException>(invocation, e)));
        }
        protected override void OnSuccess(IInvocation invocation) 
        {
            _loggerServiceBase.Info(string.Format(AspectMessages.LogSuccess, GetLogDetail<LogDetail>(invocation)));
        }
    }
}
