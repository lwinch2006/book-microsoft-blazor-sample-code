namespace WasmHosted.Server.Models.PizzaRestaurant.Requests;

public class CreateOrderRequest
{
    public Guid CustomerId { get; init; }
    public IEnumerable<int> Pizzas { get; init; } = Enumerable.Empty<int>();
}