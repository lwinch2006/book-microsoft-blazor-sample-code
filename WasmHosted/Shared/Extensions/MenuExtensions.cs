using WasmHosted.Shared.ViewModels;
using WasmHosted.Shared.ViewModels.PizzaRestaurant;

namespace WasmHosted.Shared.Extensions;

public static class MenuExtensions
{
    public static void AddPizza(this MenuVm menuVm, PizzaVm pizzaVm)
    {
        menuVm.Pizzas.Add(pizzaVm);
    }

    public static PizzaVm? GetPizza(this MenuVm menuVm, int id)
    {
        return menuVm.Pizzas.SingleOrDefault(t => t.Id == id);
    }
}