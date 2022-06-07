using System.Net.Http.Json;
using WasmHosted.Shared;

namespace Wasm.Services;

public class WeatherForecastService
{
	private readonly IHttpClientFactory _httpClientFactory;
	
	public WeatherForecastService(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}
	
	public async Task<WeatherForecast[]> GetForecastAsync()
	{
		var httpClient = _httpClientFactory.CreateClient(nameof(WeatherForecastHttpClient));

		var result = await httpClient.GetFromJsonAsync<WeatherForecast[]>("ProtectedWeatherForecast") ?? Array.Empty<WeatherForecast>();

		return result;
	}
	
	
}