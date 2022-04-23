using System.Net.Http.Json;
using Fluxor;
using WasmHosted.Shared.Redux.Actions;

namespace WasmHosted.Shared.Redux.Effects;

public class FetchDataActionEffect : Effect<FetchDataAction>
{
	private readonly HttpClient _httpClient;
	
	public FetchDataActionEffect(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}
	
	public override async Task HandleAsync(FetchDataAction action, IDispatcher dispatcher)
	{
		var forecasts = await _httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
		forecasts ??= Array.Empty<WeatherForecast>();
		var secondAction = new FetchDataResultAction(Forecasts: forecasts);
		dispatcher.Dispatch(secondAction);
	}
}