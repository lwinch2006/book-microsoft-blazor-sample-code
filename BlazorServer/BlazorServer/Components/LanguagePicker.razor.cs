using System.Globalization;
using BlazorServer.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace BlazorServer.Components;

public partial class LanguagePicker : ComponentBase
{
	private string SelectedCulture { get; set; } = CultureInfo.CurrentUICulture.Name;

	private Dictionary<string, string>? Cultures { get; set; }

	[Inject] 
	private IStringLocalizer<LanguagePicker> T { get; set; } = default!;

	[Inject] 
	private IConfiguration Configuration { get; set; } = default!;

	[Inject]
	private NavigationManager NavigationManager { get; set; } = default!;

	protected override void OnInitialized()
	{
		Cultures = Configuration.GetSupportedCultures();
	}

	private void RequestCultureChange()
	{
		if (string.IsNullOrWhiteSpace(SelectedCulture))
		{
			return;
		}

		var uri = new Uri(NavigationManager.Uri).GetComponents(UriComponents.PathAndQuery, UriFormat.Unescaped);
		var query = $"?culture={Uri.EscapeDataString(SelectedCulture)}&redirectUri={Uri.EscapeDataString(uri)}";
		NavigationManager.NavigateTo($"/Culture/SetCulture/{query}", forceLoad: true);
	}
}