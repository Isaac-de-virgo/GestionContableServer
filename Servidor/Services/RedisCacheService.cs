using Newtonsoft.Json;
using Servidor.Interfaces;
using StackExchange.Redis;

namespace Servidor.Services
{
    public class RedisCacheService : ICacheService
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisCacheService(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public async Task SetCacheAsync<T>(string key, T value, TimeSpan expiration)
        {
            var db = _redis.GetDatabase();
            // Serializa la colección en un string JSON
            var jsonData = JsonConvert.SerializeObject(value);
            await db.StringSetAsync(key, jsonData, expiration);
        }

        public async Task<T?> GetCacheAsync<T>(string key)
        {
            var db = _redis.GetDatabase();
            var jsonData = await db.StringGetAsync(key);

            if (jsonData.IsNullOrEmpty)
                return default;

            // Deserializa el JSON de vuelta al tipo original
            return JsonConvert.DeserializeObject<T>(jsonData);
        }
    }
}
