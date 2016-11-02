using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using YB.Mall.Core;

namespace YB.Mall.NetCache
{
    public class AspNet : ICache
    {
        private readonly System.Web.Caching.Cache _cache = HttpRuntime.Cache;
        private static object _cacheLocker = new object();
        public object Get(string key)
        {
            return this._cache.Get(key);
        }

        public T Get<T>(string key) where T : class
        {
            return (T)this._cache.Get(key);
        }

        public void Insert(string key, object data)
        {
            if (this._cache.Get(key) != null)
                this._cache.Remove(key);
            this._cache.Insert(key, data);
        }

        public void Insert(string key, object data, int expirtime)
        {
            if (this._cache.Get(key) != null)
                this._cache.Remove(key);
            this._cache.Insert(key, data, null, DateTime.Now.AddSeconds((double)expirtime), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
        }

        public bool Replace(string key, object data, int expirtime)
        {
            var flag = true;
            _cache.Remove(key);
            _cache.Insert(key, data, null,
                DateTime.Now.AddHours(expirtime), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High,
                null);
            if (this._cache.Get(key) == null)
                flag = false;
            return flag;
        }

        public void Remove(string key)
        {
            var enumerator = this._cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var ckey = enumerator.Key.ToString();
                if (!ckey.StartsWith(key)) continue;
                _cache.Remove(ckey);
            }
        }
    }
}
