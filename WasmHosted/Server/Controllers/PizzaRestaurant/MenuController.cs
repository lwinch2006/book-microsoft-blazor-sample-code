using Microsoft.AspNetCore.Mvc;
using WasmHosted.Server.Services.PizzaRestaurant;
using WasmHosted.Shared.ViewModels.PizzaRestaurant;

namespace WasmHosted.Server.Controllers.PizzaRestaurant;

[ApiController]
[Route("PizzaRestaurant/[controller]")]
public class MenuController : ControllerBase
{
    private readonly IMenuService _menuService;

    public MenuController(IMenuService menuService)
    {
        _menuService = menuService;
    }
    
    [HttpGet]
    public async Task<ActionResult<MenuVm>> Get()
    {
        await Task.Delay(1000);
        
        var menu = await _menuService.Get();
        var menuVm = MenuMapper.Map(menu);
        return await Task.FromResult(menuVm);
    }
}