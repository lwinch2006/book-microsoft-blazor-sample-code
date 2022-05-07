using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace WasmHosted.Server.Controllers.Localization;

[ApiController]
[Route("[controller]")]
public class LocalizationController : ControllerBase
{
	[HttpGet("[action]")]
	public IActionResult GetMondays()
	{
		var cultureNo = new CultureInfo("nb-NO");
		var cultureSv = new CultureInfo("sv-SE");

		var mondays = new[]
		{
			cultureNo.DateTimeFormat.GetDayName(DayOfWeek.Monday),
			cultureSv.DateTimeFormat.GetDayName(DayOfWeek.Monday)
		};
		
		return Ok(mondays);
	}
}