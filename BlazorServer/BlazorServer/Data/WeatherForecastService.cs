namespace BlazorServer.Data;

public class WeatherForecastService
{
	private readonly IHttpClientFactory _httpClientFactory;
	
	private static readonly string[] Summaries = new[]
	{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	};

	public WeatherForecastService(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}

	public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
	{
		var httpClient = _httpClientFactory.CreateClient(nameof(WeatherForecastService));

		var result = await httpClient.GetFromJsonAsync<WeatherForecast[]>("ProtectedWeatherForecast") ?? Array.Empty<WeatherForecast>();

		return result;
	}
}