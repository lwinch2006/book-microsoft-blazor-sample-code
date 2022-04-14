namespace WasmHosted.Shared.ViewModels.PizzaRestaurant;

public class MenuVm
{
    public ICollection<PizzaVm> Pizzas { get; init; } = new List<PizzaVm>();
}