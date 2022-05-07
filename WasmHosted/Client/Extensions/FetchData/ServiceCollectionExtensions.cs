using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using WasmHosted.Client.Services.FetchData;

namespace WasmHosted.Client.Extensions.FetchData;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddFetchDataWithgRPCServices(this IServiceCollection services)
	{
		services
			.AddScoped<IFetchDataWithgRPCClientService, FetchDataWithgRPCClientService>()
			.AddScoped(sp =>
			{
				var configuration = sp.GetRequiredService<IConfiguration>();
				var serverUrl = configuration["FetchDataWithgRPC:Server"];
				var httpHandler = new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler());
				return GrpcChannel.ForAddress(serverUrl, new GrpcChannelOptions
				{
					HttpHandler = httpHandler,
					MaxReceiveMessageSize = null
				});
			});


		return services;
	}
}