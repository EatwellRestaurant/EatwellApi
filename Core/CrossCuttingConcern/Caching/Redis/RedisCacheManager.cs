using Newtonsoft.Json;
using StackExchange.Redis;

namespace Core.CrossCuttingConcern.Caching.Redis
{
    public class RedisCacheManager : ICacheService
    {
        readonly IDatabase _redisCache;

        public RedisCacheManager(RedisClient redisClient)
        {
            _redisCache = redisClient.RedisCache;
        }


        public T GetData<T>(string key)
        {
            RedisValue value = _redisCache.StringGet(key);

            if (!string.IsNullOrEmpty(value))
                return JsonConvert.DeserializeObject<T>(value);

            return default;
        }


        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            TimeSpan expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
            
            return _redisCache.StringSet(key, JsonConvert.SerializeObject(value), expiryTime);
        }


        public bool RemoveData(string key)
        {
            bool _isKeyExist = _redisCache.KeyExists(key);

            if (_isKeyExist == true)
            {
                return _redisCache.KeyDelete(key);
            }
            
            return false;
        }


        public void Refresh(string key, TimeSpan newExpiration)
        {
            _redisCache.KeyExpire(key, newExpiration);
        }
    }
}
