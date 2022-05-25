using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlazorServer.Pages;

public class Logout : PageModel
{
	public IActionResult OnGet()
	{
		var authProperties = new AuthenticationProperties
		{
			RedirectUri = "/"
		};

		return SignOut(
			authProperties, 
			CookieAuthenticationDefaults.AuthenticationScheme, 
			OpenIdConnectDefaults.AuthenticationScheme);
	}
}