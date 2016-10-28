using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Builder;
using Autofac.Configuration;
using YB.Mall.Extend.Log;

namespace YB.Mall.Core
{
    public static class Cache
    {
        private static ICache _cache = null;
        private static readonly object _cacheLocker = new object();
        static Cache()
        {
            Load();
        }
        public static object Get(string key)
        {
            lock (_cacheLocker)
            {
                return string.IsNullOrWhiteSpace(key) ? null : _cache.Get(key);
            }
        }

        public static T Get<T>(string key) where T : class
        {
            lock (_cacheLocker)
            {
                return string.IsNullOrWhiteSpace(key) ? null : _cache.Get<T>(key);
            }
        }

        public static void Insert(string key, object data)
        {
            if (string.IsNullOrWhiteSpace(key) || (data == null)) return;
            lock (_cacheLocker)
            {
                _cache.Insert(key, data);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="expirtime">分钟</param>
        public static void Insert(string key, object data, int expirtime)
        {
            if (string.IsNullOrWhiteSpace(key) || (data == null)) return;
            lock (_cacheLocker)
            {
                _cache.Insert(key, data, expirtime);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="expirtime">分钟</param>
        /// <returns></returns>
        public static bool Replace(string key, object data, int expirtime)
        {
            if (!string.IsNullOrWhiteSpace(key) && (data != null))
            {
                lock (_cacheLocker)
                {
                    return _cache.Replace(key, data, expirtime);
                }
            }
            else
                return false;
        }
        public static void Remove(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return;
            lock (_cacheLocker)
            {
                _cache.Remove(key);
            }
        }
        /// <summary>
        /// 加载
        /// </summary>
        private static void Load()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ICache>();
            builder.RegisterModule(new ConfigurationSettingsReader("autofac"));
            IContainer context = null;
            try
            {
                context = builder.Build(ContainerBuildOptions.None);
                lock (_cacheLocker)
                {
                    _cache = context.Resolve<ICache>();
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception);
            }
            finally
            {
                if (context != null)
                {
                    context.Dispose();
                }
            }
        }
    }
}
