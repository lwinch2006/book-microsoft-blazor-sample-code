namespace WasmHosted.Shared.Services;

public interface IApiClient
{
    Task<WeatherForecast[]?> GetWeatherForecast();
}