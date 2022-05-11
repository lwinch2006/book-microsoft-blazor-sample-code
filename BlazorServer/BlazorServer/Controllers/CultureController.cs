using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServer.Controllers;

[Route("[controller]/[action]")]
public class CultureController : Controller
{
	public IActionResult SetCulture(string culture, string redirectUri)
	{
		if (string.IsNullOrWhiteSpace(culture))
		{
			return RedirectBack(redirectUri);
		}
		
		HttpContext.Response.Cookies.Append(
			CookieRequestCultureProvider.DefaultCookieName, 
			CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)));

		return RedirectBack(redirectUri);
	}

	private IActionResult RedirectBack(string redirectUri)
	{
		return LocalRedirect(string.IsNullOrWhiteSpace(redirectUri) 
			? "/index" 
			: redirectUri);
	}
}