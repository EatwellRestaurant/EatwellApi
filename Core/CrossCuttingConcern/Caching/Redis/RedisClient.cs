using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace Core.CrossCuttingConcern.Caching.Redis
{
    public class RedisClient
    {
        readonly RedisSettings _redisSettings;
        readonly ConnectionMultiplexer _connectionMultiplexer;
        public IDatabase RedisCache;

        public RedisClient(IConfiguration configuration)
        {
            _redisSettings = configuration.GetSection("RedisSettings").Get<RedisSettings>()!;

            ConfigurationOptions configOptions = new()
            {
                User = _redisSettings.User,
                Password = _redisSettings.Password
            };

            foreach (RedisEndpoint endpoint in _redisSettings.Endpoints)
            {
                configOptions.EndPoints.Add(endpoint.Host, endpoint.Port);
            }

            _connectionMultiplexer = ConnectionMultiplexer.Connect(configOptions);

            RedisCache = _connectionMultiplexer.GetDatabase();
        }

    }
}
