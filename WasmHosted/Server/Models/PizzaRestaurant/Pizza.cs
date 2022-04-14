using WasmHosted.Shared.Models;

namespace WasmHosted.Server.Models.PizzaRestaurant;

public class Pizza
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public decimal Price { get; init; }
    public SpicinessTypes Spiciness { get; init; }
}