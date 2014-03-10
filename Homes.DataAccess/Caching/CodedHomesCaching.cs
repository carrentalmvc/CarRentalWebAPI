using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using Homes.DataAccess.UnitofWork;
using Homes.Model;

namespace Homes.DataAccess
{
   public  class CodedHomesCaching<T> where T : class
    {
       private MemoryCache _cache = MemoryCache.Default;      

       public  IEnumerable<T> GetDataFromCache(string key)
       {
           object data = null;

           if (_cache.Contains(key))
           {
               data = _cache[key];              
           }

           else
           {
               data = new UnitofWork.UnitofWork(new HomesDataContext()).HomeRepository.GetAll();
               _cache.Add(key, data, new CacheItemPolicy { AbsoluteExpiration = DateTime.Now.AddSeconds(60000), Priority = CacheItemPriority.Default });
           }

           return data as IEnumerable<T>;
         
       }
       

    }
}
