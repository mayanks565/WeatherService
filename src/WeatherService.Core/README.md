# Weather Service

This is a Weather Service implemented in .NET Core using TDD (Test-Driven Development) approach, and best coding practices.

The service fetches weather data from the OpenWeather API for a list of cities provided in a daily file and saves the results to an output folder with proper file naming to cater for historical data.

## Table of Contents
- [Architecture](#architecture)
- [Prerequisites](#prerequisites)
- [Build and Execution](#build-and-execution)
- [Configuration](#configuration)
- [Project Structure](#project-structure)
- [Testing](#testing)
- [Technologies Used](#technologies-used)

## Architecture

This project is designed using the **Clean Architecture** pattern to maintain separation of concerns.

### Layers
1. **Core**: Contains the domain models and interfaces.
2. **Infrastructure**: Contains the implementations of services (e.g., fetching weather data, file storage).
3. **API**: The entry point of the application, responsible for handling HTTP requests.

### Key Design Patterns
- **Dependency Injection**: To manage dependencies between different layers.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or any other C# IDE.
- Access to the [OpenWeather API](https://openweathermap.org/api) and an API Key.

## Build and Execution

### Step 1: Clone the Repository

``bash
git clone https://github.com/your-username/weather-service.git
cd weather-service

### Step 2: Configure the Project

{
  "OpenWeatherApiKey": "YOUR_OPENWEATHER_API_KEY",
  "OutputDirectory": "OutputFolder",
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

### Step 3: Build the Project

dotnet build

### Step 4: Run the API

To run the API, navigate to the WeatherService.API folder and execute:
dotnet run

### Step 5: Input CityID in swaggerUI

Here is the sample extract of the city identifiers and names needed by the service.
Please create your own file that will be used by your application.

2643741=City of London
2988507=Paris
2964574=Dublin
4229546=Washington
5128581=New York
1273294=Delhi
1275339=Mumbai
6539761=Rome
2950159=Berlin
292223=Dubai

### Step 6: Check Output

After the API processes the input file, weather data for each city will be saved in the OutputFiles folder,
with the filename structured to include the date (e.g., weather_London_2024-11-13.json).

## Configuration
appsettings.json
Make sure to update appsettings.json with your configurations:

OpenWeatherApiKey: Your API key for accessing OpenWeather data.

## Project Structure

weatherServiceApp/
├── WeatherService.Core/
│   ├── Interfaces/
│   │   └── IWeatherService.cs
|   |   └── IFileStorageService.cs
│   └── Models/
│       └── WeatherInfo.cs
├── WeatherService.Infrastructure/
│   ├── Models/
│   │   └── OpenWeatherResponse.cs
│   ├── Services/
│   │   ├── FileStorageService.cs
│   │   └── OpenWeatherService.cs
├── WeatherService.API/
│   ├── Controllers/
│   │   └── WeatherController.cs
│   ├── appsettings.json
│   ├── Program.cs
└── WeatherService.Tests/
    ├── Services/
    │   ├── OpenWeatherServiceTests.cs
    │   └── WeatherServiceTests.cs
    └── HttpMessageHandlerStub.cs


## Testing

### Step 1: Set Up Tests
Unit tests are implemented using XUnit and Moq. The tests are located in the WeatherService.Tests project.

### Step 2: Run Tests

Testing Libraries Used
XUnit: Test framework.
Moq: Mocking library to simulate dependencies.
Test Examples
Parameterized Tests: Using [Theory] and [InlineData] to test multiple scenarios for IWeatherService.
Mocking External Services: Using Moq to simulate the OpenWeather API calls.

## Technologies Used
ASP.NET Core 8: For building the API.
XUnit: For unit testing.
Moq: For creating mock objects.
OpenWeather API: To retrieve weather data.
SOLID Principles: To design clean and maintainable code.
Clean Architecture: For a modular and testable codebase.

