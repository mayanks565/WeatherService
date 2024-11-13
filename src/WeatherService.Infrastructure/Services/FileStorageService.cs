using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherService.Core.Interfaces;
using WeatherService.Core.Models;

namespace WeatherService.Infrastructure.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly string _outputDirectory;

        public FileStorageService(IConfiguration configuration)
        {
            _outputDirectory = configuration["OutputDirectory"];
        }

        public async Task SaveWeatherDataAsync(WeatherInfo weatherInfo)
        {
            string fileName = $"{weatherInfo.City}_{weatherInfo.Date:yyyyMMdd}.json";
            string filePath = Path.Combine(_outputDirectory, fileName);

            var json = JsonSerializer.Serialize(weatherInfo);
            await File.WriteAllTextAsync(filePath, json);
        }
    }
}
