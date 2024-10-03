using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servidor.Interfaces;
using StackExchange.Redis;
using System.Diagnostics;

namespace Servidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisExampleController : ControllerBase
    {
        private readonly ICacheService _cacheService;

        public RedisExampleController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetData(int id)
        {
            string cacheKey = $"data_list_{id}";

            // Verificar si la lista ya está en caché
            var cachedData = await _cacheService.GetCacheAsync<List<string>>(cacheKey);
            if (cachedData != null)
            {
                return Ok(cachedData); // Devolver la lista almacenada en Redis
            }

            // Lógica para generar una lista de ejemplo (o puedes usar tu lógica de negocio)
            var data = GenerateRandomData(50000);

            // Guardar la lista en Redis con un tiempo de expiración
            await _cacheService.SetCacheAsync(cacheKey, data, TimeSpan.FromMinutes(10));

            return Ok(data);
        }
        [HttpGet("store")]
        public async Task<IActionResult> StoreData()
        {
            // Generar 10,000 cadenas aleatorias
            var randomData = GenerateRandomData(10000);

            // Medir el tiempo para almacenar los datos en Redis
            Stopwatch stopwatch = Stopwatch.StartNew();

            await _cacheService.SetCacheAsync("random_data", randomData, TimeSpan.FromMinutes(10));

            stopwatch.Stop();

            return Ok(new
            {
                Message = "Datos almacenados en Redis",
                TimeTakenMs = stopwatch.ElapsedMilliseconds
            });
        }

        [HttpGet("retrieve")]
        public async Task<IActionResult> RetrieveData()
        {
            // Medir el tiempo para recuperar los datos de Redis
            Stopwatch stopwatch = Stopwatch.StartNew();

            var cachedData = await _cacheService.GetCacheAsync<List<string>>("random_data");

            stopwatch.Stop();

            return Ok(new
            {
                Message = "Datos recuperados de Redis",
                DataCount = cachedData?.Count ?? 0,
                TimeTakenMs = stopwatch.ElapsedMilliseconds
            });
        }

        // Método para generar datos aleatorios
        private List<string> GenerateRandomData(int count)
        {
            var random = new Random();
            var data = new List<string>(count);
            for (int i = 0; i < count; i++)
            {
                // Generar una cadena aleatoria de 10 caracteres
                var randomString = new string((char)random.Next(65, 90), 10); // A-Z
                data.Add(randomString);
            }
            return data;
        }
    }
}
