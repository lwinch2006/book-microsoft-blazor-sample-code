using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlazorServer.Pages;

public class Login : PageModel
{
	public IActionResult OnGet(string redirectUrl)
	{
		if (string.IsNullOrWhiteSpace(redirectUrl))
		{
			redirectUrl = "/";
		}

		if (HttpContext.User.Identity.IsAuthenticated)
		{
			return Redirect(redirectUrl);
		}

		var authProperties = new AuthenticationProperties
		{
			RedirectUri = redirectUrl
		};

		return Challenge(authProperties, OpenIdConnectDefaults.AuthenticationScheme);
	}
}