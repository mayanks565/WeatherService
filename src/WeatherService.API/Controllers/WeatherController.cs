using Microsoft.AspNetCore.Mvc;
using WeatherService.Core.Interfaces;
using WeatherService.Core.Models;

namespace WeatherService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : Controller
    {
        private readonly IWeatherService _weatherService;
        private readonly IFileStorageService _fileStorageService;

        public WeatherController(IWeatherService weatherService, IFileStorageService fileStorageService)
        {
            _weatherService = weatherService;
            _fileStorageService = fileStorageService;
        }

        [HttpPost("process")]
        public async Task<IActionResult> ProcessWeatherData([FromBody] List<string> cities)
        {
            foreach (var city in cities)
            {
                try
                {
                    var weatherInfo = await _weatherService.GetWeatherForCityAsync(city);
                    await _fileStorageService.SaveWeatherDataAsync(weatherInfo);
                }
                catch
                {
                    return StatusCode(500, $"Failed to retrieve weather data for {city}");
                }
            }
            return Ok("Weather data processed and saved.");
        }
    }
}
