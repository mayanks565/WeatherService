using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace WeatherService.Infrastructure.Models
{
    public class OpenWeatherResponse
    {
        [JsonPropertyName("main")]
        public MainInfo Main { get; set; }

        [JsonPropertyName("weather")]
        public List<WeatherDescription> Weather { get; set; }

        [JsonPropertyName("name")]
        public string CityName { get; set; }
    }

    public class MainInfo
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }
    }

    public class WeatherDescription
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
