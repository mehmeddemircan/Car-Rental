using CarRental.Core.CrossCuttingConcerns.Logging;
using CarRental.Core.CrossCuttingConcerns.Logging.Serilog;
using CarRental.Core.Utilities.Interceptors;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Aspects.Logging
{
    public class LogAspect : MethodInterception
    {
        private readonly LoggerServiceBase _loggerServiceBase;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new ArgumentException("");
            }

            _loggerServiceBase = (LoggerServiceBase)Utilities.Helpers.HttpContext.Current.RequestServices.GetService(loggerService);
            _httpContextAccessor = (IHttpContextAccessor)Utilities.Helpers.HttpContext.Current.RequestServices.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _loggerServiceBase?.Info(GetLogDetail(invocation));
        }

        private string GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            if (invocation.Arguments != null)
            {
                for (var i = 0; i < (invocation.Arguments?.Length ?? 0); i++)
                {
                    if (invocation.Arguments[i] != null)
                    {
                        logParameters.Add(new LogParameter
                        {
                            Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                            Value = invocation.Arguments[i],
                            Type = invocation.Arguments[i]?.GetType()?.Name,
                        });
                    }
                }
            }
            var logDetail = new LogDetail
            {
                MethodName = invocation.Method.Name,
                Parameters = logParameters,
                User = (_httpContextAccessor.HttpContext == null ||
                        _httpContextAccessor.HttpContext.User.Identity.Name == null)
                    ? "?"
                    : _httpContextAccessor.HttpContext.User.Identity.Name
            };
            return JsonConvert.SerializeObject(logDetail);
        }
    }
}
