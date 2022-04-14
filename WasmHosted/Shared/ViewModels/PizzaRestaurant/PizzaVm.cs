using WasmHosted.Shared.Models;

namespace WasmHosted.Shared.ViewModels.PizzaRestaurant;

public class PizzaVm
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public decimal Price { get; init; }
    public SpicinessTypes Spiciness { get; init; }
}