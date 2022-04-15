using System.Net.Http.Json;
using WasmHosted.Shared;

namespace WasmHosted.Client.Services;

public interface IApiClient
{
    Task<WeatherForecast[]?> GetWeatherForecast();
}

public class ApiClient : IApiClient
{
    private readonly HttpClient _httpClient;
    
    public ApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<WeatherForecast[]?> GetWeatherForecast()
    {
        return await _httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
    }
}