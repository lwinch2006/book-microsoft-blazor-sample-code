using Microsoft.AspNetCore.ResponseCompression;

namespace WasmHosted.Server.Extensions.Whiteboard;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddWhiteboardServices(this IServiceCollection services)
	{
		services
			.AddResponseCompression(options =>
		{
			options.MimeTypes = ResponseCompressionDefaults.MimeTypes
				.Concat(new[] { "application/octet-stream" });
		});
		
		services.AddSignalR();

		return services;
	}
}