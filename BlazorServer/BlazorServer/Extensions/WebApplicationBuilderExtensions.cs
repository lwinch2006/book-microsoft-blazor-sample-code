namespace BlazorServer.Extensions;

public static class WebApplicationBuilderExtensions
{
	public static WebApplicationBuilder ConfigureBuilder(this WebApplicationBuilder builder)
	{
		builder.Services
			.AddApplication()
			.AddAuthenticationServices()
			.AddLocalization()
			.AddHttpContextAccessor()
			.AddServerSideBlazor().Services
			.AddRazorPages().Services
			.AddControllers();
		
		return builder;
	}

	public static WebApplication CreateApp(this WebApplicationBuilder builder)
	{
		return builder.Build();
	}
}