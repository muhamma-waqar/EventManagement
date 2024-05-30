using Microsoft.EntityFrameworkCore.Storage;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class RedisCacheService : IRedisCacheService
    {

        private readonly StackExchange.Redis.IDatabase _cache;

        public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            _cache = connectionMultiplexer.GetDatabase();
        }

        // Method to set a value in Redis
        public void Set<T>(string key, T value)
        {
           // var json = JsonSerializer.Serialize(value);
            _cache.StringSet(key, value.ToString());
        }

        // Method to get a value from Redis
        public IEnumerable<T> Get<T>(string key)
        {
            RedisValue redisValue = _cache.StringGet(key);
            if (redisValue.IsNullOrEmpty)
            {
                return default(IEnumerable<T>);
            }
            var jsonString = redisValue.ToString();
            return JsonSerializer.Deserialize<IEnumerable<T>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ;
        }
    }
}
