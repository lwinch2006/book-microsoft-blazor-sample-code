using Microsoft.AspNetCore.Mvc;
using WasmHosted.Server.Services.PizzaRestaurant;
using WasmHosted.Shared.ViewModels;
using WasmHosted.Shared.ViewModels.PizzaRestaurant;

namespace WasmHosted.Server.Controllers.PizzaRestaurant;

[ApiController]
[Route("PizzaRestaurant/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrdersService _ordersService;

    public OrdersController(IOrdersService ordersService)
    {
        _ordersService = ordersService;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<OrderVm>> Get(Guid id)
    {
        return await Task.FromResult(new OrderVm());
    }
    
    [HttpPost]
    public async Task<ActionResult> Post(ShoppingBasketVm viewModel)
    {
        var createOrderRequest = OrdersMapper.Map(viewModel);
        var order = await _ordersService.Create(createOrderRequest);
        var orderVm = OrdersMapper.Map(order);
        
        return CreatedAtAction(nameof(Get), new { id = orderVm.OrderId }, orderVm);
    }
}