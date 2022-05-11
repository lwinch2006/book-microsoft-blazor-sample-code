using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using WasmHosted.Client.Extensions.PizzaRestaurant;

namespace WasmHosted.Client.Components.Localization;

public partial class LanguagePicker : ComponentBase
{
	private string SelectedCulture
	{
		get => CultureInfo.CurrentCulture.Name;
		
		set
		{
			if (SelectedCulture == value)
			{
				return;
			}
			
			var js = (IJSInProcessRuntime)JsRuntime;
			js.InvokeVoid("blazorCulture.set", value);
			var cultureInfo = new CultureInfo(value);
			CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
			CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
			NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
		}
	}
	
	private Dictionary<string, string>? Cultures { get; set; }
	
	[Inject] 
	private IConfiguration Configuration { get; set; } = default!;
	
	[Inject] 
	private IStringLocalizer<LanguagePicker> T { get; set; } = default!;

	[Inject]
	private IJSRuntime JsRuntime { get; set; } = default!;

	[Inject]
	private NavigationManager NavigationManager { get; set; } = default!;

	protected override void OnInitialized()
	{
		Cultures = Configuration.GetSupportedCultures();
		
		if (!Cultures.ContainsKey(SelectedCulture))
		{
			SelectedCulture = Cultures.ElementAt(0).Key;
		}
	}
}