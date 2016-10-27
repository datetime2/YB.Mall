namespace YB.Mall.Core
{
    public interface ICache : IStrategy
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns></returns>
        object Get(string key);
        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">缓存键</param>
        /// <returns></returns>
        T Get<T>(string key) where T : class;
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存数据</param>
        void Insert(string key, object data);
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存数据</param>
        void Insert(string key, object data, int expirtime);
        /// <summary>
        /// 替换
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="expirtime"></param>
        /// <returns></returns>
        bool Replace(string key, object data, int expirtime);
        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="key">缓存键</param>
        void Remove(string key);
        
    }
}