namespace WasmHosted.Shared.ViewModels.PizzaRestaurant;

public class ShoppingBasketVm
{
    public CustomerVm Customer { get; set; } = new CustomerVm();
    public ICollection<int> Pizzas { get; } = new List<int>();
    public bool HasPaid { get; set; }
}