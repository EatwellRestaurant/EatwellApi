using EatwellApi.Application.Abstractions.Cache;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace EatwellApi.Infrastructure.Services.Cache.RedisCache
{
    public class RedisCacheService(IConnectionMultiplexer connectionMultiplexer) : ICacheService
    {

        readonly IDatabase _database = connectionMultiplexer.GetDatabase();
        static readonly JsonSerializerSettings _jsonSettings = new()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore
        };



        public async Task<T?> GetAsync<T>(string key)
        {
            RedisValue value = await _database.StringGetAsync(key);

            if (value.HasValue)
                return JsonConvert.DeserializeObject<T>(value!, _jsonSettings);

            return default;
        }



        public async Task SetAsync<T>(string key, T value, TimeSpan? expirationTime = null)
            => await _database.StringSetAsync(
                key,
                JsonConvert.SerializeObject(value, _jsonSettings),
                expirationTime
               );




        public async Task RemoveAsync(string key)
            => await _database.KeyDeleteAsync(key);



        public async Task RemoveRangeAsync(params string[] keys)
        {
            RedisKey[] redisKeys = keys.Select(k => (RedisKey)k).ToArray();

            await _database.KeyDeleteAsync(redisKeys);
        }


    }
}
