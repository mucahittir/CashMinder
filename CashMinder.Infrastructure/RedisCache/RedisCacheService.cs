using CashMinder.Application.Interfaces.RedisCache;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace CashMinder.Infrastructure.RedisCache
{
    public class RedisCacheService : IRedisCacheService
    {

        private readonly ConnectionMultiplexer redisConnection;
        private readonly IDatabase database;
        private readonly RedisCacheSettings settings;

        public RedisCacheService(IOptions<RedisCacheSettings> options)
        {
            settings = options.Value;
            redisConnection = ConnectionMultiplexer.Connect(settings.ConnectionString);
            database = redisConnection.GetDatabase();
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var value = await database.StringGetAsync(key);
            if(value.HasValue)
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            return default;
            
        }
        public async Task SetAsync<T>(string key, T value, DateTime? expirationTime = null)
        {
            TimeSpan timeUnitExpiration = expirationTime.HasValue ? expirationTime.Value - DateTime.Now : TimeSpan.Zero;
            await database.StringSetAsync(key, JsonConvert.SerializeObject(value), timeUnitExpiration);

        }
        public Task RemoveAsync(string key)
        {
            throw new NotImplementedException();
        }

    }
}