namespace Wasm.Services;

public class WeatherForecastHttpClient
{
	private readonly HttpClient _httpClient;
	
	public WeatherForecastHttpClient(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}
}