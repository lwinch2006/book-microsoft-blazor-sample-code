using Grpc.Net.Client;
using WasmHosted.Shared;
using WasmHosted.Shared.gRPC;

namespace WasmHosted.Client.Services.FetchData;

public interface IFetchDataWithgRPCClientService
{
	Task<IEnumerable<WeatherForecast>> GetWeatherForecasts();
}

public class FetchDataWithgRPCClientService : IFetchDataWithgRPCClientService
{
	private readonly GrpcChannel _grpcChannel;

	public FetchDataWithgRPCClientService(GrpcChannel grpcChannel)
	{
		_grpcChannel = grpcChannel;
	}
	
	public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts()
	{
		var grpcClient = new protoWeatherForecast.protoWeatherForecastClient(_grpcChannel);

		var request = new getWeatherForecastRequest();

		getWeatherForecastResponse? response = await grpcClient.getWeatherForecastsAsync(request);

		var mappedResponse = response?.Forecasts.Select(f => new WeatherForecast
		{
			Date = f.Date.ToDateTime(),
			TemperatureC = f.TemperatureC,
			Summary = f.Summary
		}) ?? Enumerable.Empty<WeatherForecast>();

		return mappedResponse;
	}
}