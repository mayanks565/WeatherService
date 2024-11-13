using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherService.Core.Models;

namespace WeatherService.Core.Interfaces
{
    public interface IFileStorageService
    {
        Task SaveWeatherDataAsync(WeatherInfo weatherInfo);
    }
}
