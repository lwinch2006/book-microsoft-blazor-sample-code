namespace BlazorServer.Extensions;

public static class WebApplicationExtensions
{
	public static WebApplication ConfigureApp(this WebApplication app)
	{
		if (!app.Environment.IsDevelopment())
		{
			app
				.UseExceptionHandler("/Error")
				.UseHsts();
		}

		app
			.UseRequestLocalization(LocalizationExtensions.GetLocalizationOptions(app.Configuration))
			.UseHttpsRedirection()
			.UseStaticFiles()
			.UseRouting()
			.UseAuthentication()
			.UseAuthorization()
			.Use(() => app.MapBlazorHub())
			.Use(() => app.MapControllers())
			.Use(() => app.MapFallbackToPage("/_Host"));

		return app;
	}
}