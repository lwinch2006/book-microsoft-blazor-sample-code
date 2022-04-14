using WasmHosted.Server.Models.PizzaRestaurant;
using WasmHosted.Server.Models.PizzaRestaurant.Requests;
using WasmHosted.Shared.ViewModels.PizzaRestaurant;

namespace WasmHosted.Server.Services.PizzaRestaurant;

public static class OrdersMapper
{
    public static CreateOrderRequest Map(ShoppingBasketVm source)
    {
        var destination = new CreateOrderRequest
        {
            CustomerId = Guid.NewGuid(),
            Pizzas = source.Pizzas
        };

        return destination;
    }
    
    public static Order Map(CreateOrderRequest source)
    {
        var destination = new Order
        {
            OrderId = Guid.NewGuid(),
            CustomerId = source.CustomerId,
            Pizzas = source.Pizzas,
            CreatedOn = DateTime.Now
        };

        return destination;
    }

    public static OrderVm Map(Order source)
    {
        var destination = new OrderVm
        {
            OrderId = source.OrderId,
            CustomerId = source.CustomerId,
            Pizzas = source.Pizzas,
            CreatedOn = source.CreatedOn
        };

        return destination;
    }
}