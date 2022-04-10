namespace WasmHosted.Shared.ViewModels;

public class Menu
{
    public ICollection<Pizza> Pizzas { get; } = new List<Pizza>();
}