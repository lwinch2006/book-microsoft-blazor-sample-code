using BlazorServer.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace BlazorServer.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services
			.AddSingleton<WeatherForecastService>();

		return services;
	}

	public static IServiceCollection AddAuthenticationServices(this IServiceCollection services)
	{
		services
			.AddAuthentication(options =>
			{
				options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
			})
			.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
			.AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
			{
				options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
				options.Authority = "https://localhost:5011";
				options.ClientId = "blazor-book-server-app";
				options.ClientSecret = "u2u-secret";
				options.ResponseType = "code id_token";
				options.CallbackPath = "/signin-oidc";
				options.SignedOutCallbackPath = "/signout-callback-oidc";
				options.RemoteSignOutPath = "/signout-oidc";

				options.GetClaimsFromUserInfoEndpoint = true;
				options.SaveTokens = true;
				options.ClaimActions.MapAll();
				
				options.Events.OnRedirectToIdentityProviderForSignOut = async ctx =>
				{
					var idToken = await ctx.HttpContext.GetTokenAsync("id_token");
					ctx.ProtocolMessage.IdTokenHint = idToken;
				};
			});
		
		return services;
	}
}