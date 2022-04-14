namespace WasmHosted.Server.Models.PizzaRestaurant;

public class Menu
{
    public ICollection<Pizza> Pizzas { get; } = new List<Pizza>();
}