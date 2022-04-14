using WasmHosted.Server.Models.PizzaRestaurant;
using WasmHosted.Server.Models.PizzaRestaurant.Requests;

namespace WasmHosted.Server.Services.PizzaRestaurant;

public interface IOrdersService
{
    Task<Order> Create(CreateOrderRequest createOrderRequest);
}


public class OrdersService : IOrdersService
{
    public async Task<Order> Create(CreateOrderRequest createOrderRequest)
    {
        var order = OrdersMapper.Map(createOrderRequest);
        return await Task.FromResult(order);
    }
}