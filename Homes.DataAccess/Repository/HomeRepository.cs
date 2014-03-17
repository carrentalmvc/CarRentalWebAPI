using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using Homes.Model;

namespace Homes.DataAccess.Repository
{
    public class HomeRepository : GenericRepository<Home>
    {
        public HomeRepository(IDbContext cxt)
            : base(cxt)
        {
        }

        public override IQueryable<Home> GetAll()
        {
            var key = "Home_Entity_Cache_Key";
            var data = this.GetDataFromCache(key);

            return data.AsQueryable<Home>();
        }

        //To DO: Move this to a more structed utility Project
        public IEnumerable<Home> GetDataFromCache(string key)
        {
            var _cache = MemoryCache.Default;
            object data = null;

            if (_cache.Contains(key))
            {
                data = _cache[key];
            }
            else
            {
                data = base.GetAll();
                _cache.Add(key, data, new CacheItemPolicy { AbsoluteExpiration = DateTime.Now.AddSeconds(60000), Priority = CacheItemPriority.Default });
            }

            return data as IEnumerable<Home>;
        }
    }
}