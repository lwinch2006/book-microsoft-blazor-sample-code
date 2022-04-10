using WasmHosted.Shared.ViewModels;

namespace WasmHosted.Shared.Extensions;

public static class MenuExtensions
{
    public static void AddPizza(this Menu menu, Pizza pizza)
    {
        menu.Pizzas.Add(pizza);
    }

    public static Pizza? GetPizza(this Menu menu, int id)
    {
        return menu.Pizzas.SingleOrDefault(t => t.Id == id);
    }
}