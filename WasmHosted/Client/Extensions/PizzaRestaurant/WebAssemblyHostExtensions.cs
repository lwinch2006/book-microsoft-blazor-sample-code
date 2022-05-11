using System.Globalization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

namespace WasmHosted.Client.Extensions.PizzaRestaurant;

public static class WebAssemblyHostExtensions
{
	public static async Task SetDefaultCulture(this WebAssemblyHost host)
	{
		var jsRuntime = host.Services.GetRequiredService<IJSRuntime>();
		var result = await jsRuntime.InvokeAsync<string>("blazorCulture.get");

		if (!string.IsNullOrWhiteSpace(result))
		{
			var cultureInfo = new CultureInfo(result);
			CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
			CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
		}
	}
}