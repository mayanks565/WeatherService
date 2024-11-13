using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherService.Core.Interfaces;
using WeatherService.Core.Models;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using WeatherService.Infrastructure.Models;

namespace WeatherService.Infrastructure.Services
{
    public class OpenWeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public OpenWeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["OpenWeatherApiKey"];
        }

        public async Task<WeatherInfo> GetWeatherForCityAsync(string city)
        {
            var response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?id={city}&appid={_apiKey}");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Error fetching weather data.");
            }

            var content = await response.Content.ReadAsStringAsync();
            var weatherData = JsonSerializer.Deserialize<OpenWeatherResponse>(content);

            return new WeatherInfo
            {
                City = weatherData.CityName,
                Temperature = weatherData.Main.Temp,
                Description = weatherData.Weather[0].Description,
                Date = DateTime.Today
            };
        }   
    }
}
