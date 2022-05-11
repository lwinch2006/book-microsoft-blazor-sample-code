using Microsoft.AspNetCore.Localization;

namespace BlazorServer.Extensions;

public static class LocalizationExtensions
{
	public static RequestLocalizationOptions GetLocalizationOptions(IConfiguration configuration)
	{
		var supportedCultures = configuration.GetSupportedCultures();
		var supportedCultureCodes = supportedCultures.Keys.ToArray();

		var localizationOptions = new RequestLocalizationOptions()
			.SetDefaultCulture(supportedCultureCodes[0])
			.AddSupportedCultures(supportedCultureCodes)
			.AddSupportedUICultures(supportedCultureCodes);
		
		localizationOptions.RequestCultureProviders.Clear();
		localizationOptions.RequestCultureProviders.Add(new QueryStringRequestCultureProvider());
		localizationOptions.RequestCultureProviders.Add(new AcceptLanguageHeaderRequestCultureProvider());
		localizationOptions.RequestCultureProviders.Add(new CookieRequestCultureProvider());

		return localizationOptions;
	}
}