using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;
using YB.Mall.Core;
using YB.Mall.Extend.Helper;

namespace YB.Mall.RedisCache
{
    public class Redis : ICache
    {
        private static RedisConfig RedisConfig
        {
            get
            {
                try
                {
                    return ConfigUtility<RedisConfig>.GetConfig(IoHelper.GetMapPath("/Config/Redis.config"));
                }
                catch
                {
                    return new RedisConfig
                    {
                        Host = "127.0.0.1",
                        Prot = 6379
                    };
                }
            }
        }
        public object Get(string key)
        {
            using (var client = new RedisClient(RedisConfig.Host, RedisConfig.Prot))
            {
                return client.Get<object>(key);
            }
        }

        public T Get<T>(string key) where T : class
        {
            using (var client = new RedisClient(RedisConfig.Host, RedisConfig.Prot))
            {
                return client.Get<T>(key);
            }
        }

        public void Insert(string key, object data)
        {
            using (var client = new RedisClient(RedisConfig.Host, RedisConfig.Prot))
            {
                if (client.Get(key) == null)
                    client.Set(key, data);
                else
                    client.Replace(key, data);
            }
        }

        public void Insert(string key, object data, int expirtime)
        {
            using (var client = new RedisClient(RedisConfig.Host, RedisConfig.Prot))
            {
                if (client.Get(key) == null)
                    client.Set(key, data, new TimeSpan(0, expirtime, 0));
                else
                    client.Replace(key, data, new TimeSpan(0, expirtime, 0));
            }
        }

        public bool Replace(string key, object data, int expirtime)
        {
            using (var client = new RedisClient(RedisConfig.Host, RedisConfig.Prot))
            {
                return client.Replace(key, data, new TimeSpan(expirtime, 0, 0));
            }
        }

        public void Remove(string key)
        {
            using (var client = new RedisClient(RedisConfig.Host, RedisConfig.Prot))
            {
                client.Del(key);
            }
        }
    }
}
