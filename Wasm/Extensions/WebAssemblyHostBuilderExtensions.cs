using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Wasm.Services;

namespace Wasm.Extensions;

public static class WebAssemblyHostBuilderExtensions
{
	public static WebAssemblyHostBuilder ConfigureBuilder(this WebAssemblyHostBuilder builder)
	{
		builder.RootComponents.Add<App>("#app");
		builder.RootComponents.Add<HeadOutlet>("head::after");

		builder.Services
			.AddApplication()
			.AddAuthenticationServices(builder.Configuration)
			.AddHttpClient<WeatherForecastHttpClient>(httpClient =>
			{
				httpClient.BaseAddress = new Uri("https://localhost:5556");
			})
			.AddHttpMessageHandler(sp =>
			{
				var handler = sp
					.GetRequiredService<AuthorizationMessageHandler>()
					.ConfigureHandler(
						authorizedUrls: new[] { "https://localhost:5556" }, 
						scopes: new[] { "blazor-book-hosted-app-api.read" });

				return handler;
			});


		return builder;
	}

	public static WebAssemblyHost CreateApp(this WebAssemblyHostBuilder builder)
	{
		return builder.Build();
	}
}