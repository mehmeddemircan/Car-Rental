using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class CacheManager : ICacheService
    {
        IMemoryCache _memoryCache;

        public CacheManager()
        {
            _memoryCache =(IMemoryCache) Utilities.Helpers.HttpContext.Current.RequestServices.GetService(typeof(IMemoryCache));
        }
    
        public void Add(string key, object data, int duration)
        {
             _memoryCache.Set(key,data,TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public bool isAdd(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}
