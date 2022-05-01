using WasmHosted.Server.Services.FetchData;

namespace WasmHosted.Server.Extensions.FetchData;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddFetchDataWithgRPCServices(this IServiceCollection services)
	{
		services
			.AddGrpc();

		return services;
	}
	
	
	
	
}