using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp.Dom;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using WasmHosted.Client.Pages;
using WasmHosted.Client.Services;
using WasmHosted.Shared;
using Xunit;

namespace WasmHosted.ClientTests.Pages;

public class FetchData1Tests : TestContext
{
    private readonly Mock<IApiClient> _apiClient;
    
    public FetchData1Tests()
    {
        _apiClient = new Mock<IApiClient>();
    }

    [Fact]
    public void Test_InitialSetup_ShouldPass()
    {
        SetupApiClientToReturnNull();
        Services.AddSingleton(_apiClient.Object);

        var component = RenderComponent<FetchData1>();
        component.FindAll("p")[1].MarkupMatches("<p><em>Loading...</em></p>");
    }

    [Fact]
    public void Test_ReturnsWeatherForecatsFromApi_ShouldPass()
    {
        SetupApiClientToReturnNotEmpty();
        Services.AddSingleton(_apiClient.Object);

        var component = RenderComponent<FetchData1>();
        var count = component.FindAll("tbody > tr").Count;
        
        Assert.Equal(2, count);
    }

    private void SetupApiClientToReturnNull()
    {
        _apiClient.Setup(t => t.GetWeatherForecast()).Returns(() => Task.FromResult((WeatherForecast[]?) null));
    }

    private void SetupApiClientToReturnNotEmpty()
    {
        _apiClient.Setup(t => t.GetWeatherForecast()).Returns(() =>
        {
            var response = new[]
            {
                new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(1),
                    TemperatureC = 10,
                    Summary = "Good"
                },
                new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(2),
                    TemperatureC = 20,
                    Summary = "Very good"
                }
            };

            return Task.FromResult(response)!;
        });
    }
}