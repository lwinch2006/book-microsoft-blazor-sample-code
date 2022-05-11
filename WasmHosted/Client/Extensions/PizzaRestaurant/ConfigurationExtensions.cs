namespace WasmHosted.Client.Extensions.PizzaRestaurant;

public static class ConfigurationExtensions
{
	public static Dictionary<string, string> GetSupportedCultures(this IConfiguration configuration)
	{
		return configuration.GetSection("Cultures").GetChildren().ToDictionary(t => t.Key, t => t.Value);
	}
}