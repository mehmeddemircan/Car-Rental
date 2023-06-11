using CarRental.Core.CrossCuttingConcerns.Caching;
using CarRental.Core.Utilities.Interceptors;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Aspects.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        string _methodName;
        ICacheService _cacheService;

        public CacheRemoveAspect(string methodName)
        {
            _methodName = methodName;
            _cacheService = (ICacheService)Utilities.Helpers.HttpContext.Current.RequestServices.GetService(typeof(ICacheService));
        }

        protected override void OnSuccess(IInvocation invocation)
        {
          
            _cacheService.Remove($"Business.Abstract.{_methodName}()");
        }
    }
}
