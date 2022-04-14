using Microsoft.AspNetCore.Components;
using WasmHosted.Shared.ViewModels;
using WasmHosted.Shared.ViewModels.PizzaRestaurant;

namespace WasmHosted.Client.Components.PizzaRestaurant;

public partial class ShoppingBasket
{
    private decimal _totalPrice;
    
    [Parameter]
    public IEnumerable<PizzaVm> OrderedPizzas { get; set; } = Enumerable.Empty<PizzaVm>();

    [Parameter]
    public EventCallback<PizzaVm> Selected { get; set; }

    protected override void OnParametersSet()
    {
        _totalPrice = OrderedPizzas.Sum(t => t.Price);
    }
}