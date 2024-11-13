using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherService.Infrastructure.Services;

namespace WeatherService.Tests.Services
{
    public class OpenWeatherServiceTests
    {
        private readonly Mock<IConfiguration> _mockConfig;
        private readonly HttpClient _httpClient;
        private readonly OpenWeatherService _weatherService;

        public OpenWeatherServiceTests()
        {
            // Mocking IConfiguration to provide an API key
            _mockConfig = new Mock<IConfiguration>();
            _mockConfig.Setup(c => c["OpenWeatherApiKey"]).Returns("fake_api_key");

            // Use HttpClient with in-memory handler for testing
            _httpClient = new HttpClient(new HttpMessageHandlerStub());

            // Initialize OpenWeatherService with mocked config and HttpClient
            _weatherService = new OpenWeatherService(_httpClient, _mockConfig.Object);
        }

        [Fact]
        public async Task GetWeatherForCityAsync_ShouldReturnWeatherInfo_ForValidCity()
        {
            // Arrange
            var city = "London";
            var expectedTemperature = 280.32;
            var expectedDescription = "clear sky";

            // Act
            var result = await _weatherService.GetWeatherForCityAsync(city);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(city, result.City);
            Assert.Equal(expectedTemperature, result.Temperature);
            Assert.Equal(expectedDescription, result.Description);
        }
    }
}
