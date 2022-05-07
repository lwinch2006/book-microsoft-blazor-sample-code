using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using WasmHosted.Shared.gRPC;
using WasmHosted.Shared.Models.FetchData;

namespace WasmHosted.Server.Services.FetchData;

public class FetchDataWithgRPCServerService : protoWeatherForecast.protoWeatherForecastBase
{
	public override Task<getWeatherForecastResponse> getWeatherForecasts(getWeatherForecastRequest request, ServerCallContext serverCallContext)
	{
		var forecasts = Enumerable.Range(1, 100).Select(index => new weatherForecast
		{
			Date = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(index)),
			TemperatureC = Random.Shared.Next(-20, 55),
			Summary = SharedConstants.SummaryTypes[Random.Shared.Next(SharedConstants.SummaryTypes.Length)]
		});

		var response = new getWeatherForecastResponse();
		response.Forecasts.AddRange(forecasts);

		return Task.FromResult(response);
	}
}