using WasmHosted.Server.Models;
using WasmHosted.Server.Models.PizzaRestaurant;
using WasmHosted.Shared.Models;

namespace WasmHosted.Server.Services.PizzaRestaurant;

public interface IMenuService
{
    Task<Menu> Get();
}

public class MenuService : IMenuService
{
    public Task<Menu> Get()
    {
        var menu = new Menu();
        menu.Pizzas.Add(new Pizza { Id = 1, Name = "Pepperoni", Price = 8.99M, Spiciness = SpicinessTypes.Spicy });
        menu.Pizzas.Add(new Pizza { Id = 2, Name = "Margarita", Price = 7.99M, Spiciness = SpicinessTypes.None });
        menu.Pizzas.Add(new Pizza { Id = 3, Name = "Diabolo", Price = 9.99M, Spiciness = SpicinessTypes.Hot });
        return Task.FromResult(menu);
    }
}