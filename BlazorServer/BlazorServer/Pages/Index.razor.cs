using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorServer.Pages;

public partial class Index : ComponentBase
{
	[Inject] 
	private AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;

	private IEnumerable<Claim> Claims { get; set; } = Enumerable.Empty<Claim>();

	private string Username { get; set; } = "Unknown";

	protected override async Task OnInitializedAsync()
	{
		var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();

		if (authState == null)
		{
			return;
		}

		Claims = authState.User.Claims;
		Username = authState.User.FindFirst("given_name")?.Value ?? "Unknown";
	}
}