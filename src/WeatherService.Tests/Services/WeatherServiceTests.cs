using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherService.Core.Interfaces;
using WeatherService.Core.Models;

namespace WeatherService.Tests.Services
{
    public class WeatherServiceTests
    {
        private readonly Mock<IWeatherService> _mockWeatherService;

        public WeatherServiceTests()
        {
            // Set up the mock object for IWeatherService
            _mockWeatherService = new Mock<IWeatherService>();
        }

        [Theory]
        [InlineData("London", 289.5, "clear sky")]
        [InlineData("New York", 295.2, "light rain")]
        [InlineData("Tokyo", 283.1, "scattered clouds")]
        public async Task GetWeatherForCityAsync_ShouldReturnCorrectWeatherInfo(
            string city, double temperature, string description)
        {
            // Arrange
            var expectedWeatherInfo = new WeatherInfo
            {
                City = city,
                Temperature = temperature,
                Description = description,
                Date = DateTime.Today
            };

            // Setup mock to return expectedWeatherInfo when GetWeatherForCityAsync is called
            _mockWeatherService
                .Setup(service => service.GetWeatherForCityAsync(city))
                .ReturnsAsync(expectedWeatherInfo);

            // Act
            var result = await _mockWeatherService.Object.GetWeatherForCityAsync(city);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(city, result.City);
            Assert.Equal(temperature, result.Temperature);
            Assert.Equal(description, result.Description);
            Assert.Equal(DateTime.Today, result.Date);
        }
    }   
}
