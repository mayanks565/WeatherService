using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.Tests
{
    public class HttpMessageHandlerStub : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Simulate a response from OpenWeather API for testing purposes
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"main\":{\"temp\":280.32},\"weather\":[{\"description\":\"clear sky\"}],\"name\":\"London\"}")
            };
            return Task.FromResult(response);
        }
    }
}
