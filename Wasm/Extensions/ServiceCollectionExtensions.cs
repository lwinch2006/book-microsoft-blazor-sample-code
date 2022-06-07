using Wasm.Services;

namespace Wasm.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services
			.AddSingleton<WeatherForecastService>();

		return services;
	}
	
	public static IServiceCollection AddAuthenticationServices(
		this IServiceCollection services, IConfiguration configuration)
	{
		services
			.AddOidcAuthentication(options =>
			{
				options.ProviderOptions.Authority = "https://localhost:5011";
				options.ProviderOptions.ClientId = "blazor-book-wasm-app";
				options.ProviderOptions.ResponseType = "code";

				options.ProviderOptions.DefaultScopes.Clear();
				options.ProviderOptions.DefaultScopes.Add("openid");
				options.ProviderOptions.DefaultScopes.Add("profile");
				options.ProviderOptions.DefaultScopes.Add("address");
				options.ProviderOptions.DefaultScopes.Add("blazor-book-hosted-app-api.read");

				options.ProviderOptions.RedirectUri = "authentication/login-callback";
				options.ProviderOptions.PostLogoutRedirectUri = "authentication/logout-callback";

				// Configure your authentication provider options here.
				// For more information, see https://aka.ms/blazor-standalone-auth
				// For binding options through appsettings.json
				// configuration.Bind("Local", options.ProviderOptions);
			});

		return services;
	}
}