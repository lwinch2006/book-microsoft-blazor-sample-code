using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WasmHosted.Shared;

namespace WasmHosted.Server.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ProtectedWeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<ProtectedWeatherForecastController> _logger;

    public ProtectedWeatherForecastController(ILogger<ProtectedWeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Authorize(Policy = "read-access")]
    public IEnumerable<WeatherForecast> Get()
    {
        foreach (var i in Enumerable.Range(1, 100))
        {
            yield return new WeatherForecast
            {
                Date = DateTime.Now.AddDays(i),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };
        }
    }
}
