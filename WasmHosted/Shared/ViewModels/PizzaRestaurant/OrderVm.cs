namespace WasmHosted.Shared.ViewModels.PizzaRestaurant;

public class OrderVm
{
    public Guid OrderId { get; set; }
    public Guid CustomerId { get; set; }
    public IEnumerable<int> Pizzas { get; set; } = Enumerable.Empty<int>();
    public DateTime CreatedOn { get; set; }
}