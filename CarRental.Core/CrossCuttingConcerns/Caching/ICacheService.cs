using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.CrossCuttingConcerns.Caching
{
    public interface ICacheService
    {

        T Get<T>(string key);
        object Get(string key);

        void Add(string key, object data , int duration);

        bool isAdd(string key);

        void Remove(string key); 

    }
}
