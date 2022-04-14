using WasmHosted.Server.Models.PizzaRestaurant;
using WasmHosted.Shared.ViewModels;
using WasmHosted.Shared.ViewModels.PizzaRestaurant;

namespace WasmHosted.Server.Services.PizzaRestaurant;

public static class MenuMapper
{
    public static MenuVm Map(Menu source)
    {
        var destination = new MenuVm
        {
            Pizzas = Map(source.Pizzas)
        };

        return destination;
    }

    public static PizzaVm Map(Pizza source)
    {
        var destination = new PizzaVm
        {
            Id = source.Id,
            Name = source.Name,
            Price = source.Price,
            Spiciness = source.Spiciness
        };

        return destination;
    }

    public static ICollection<PizzaVm> Map(IEnumerable<Pizza> source)
    {
        return source.Select(Map).ToList();
    }
}