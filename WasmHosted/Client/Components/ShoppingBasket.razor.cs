using Microsoft.AspNetCore.Components;
using WasmHosted.Shared.ViewModels;

namespace WasmHosted.Client.Components;

public partial class ShoppingBasket
{
    private decimal _totalPrice;
    
    [Parameter]
    public IEnumerable<Pizza> OrderedPizzas { get; set; } = Enumerable.Empty<Pizza>();

    [Parameter]
    public EventCallback<Pizza> Selected { get; set; }

    protected override void OnParametersSet()
    {
        _totalPrice = OrderedPizzas.Sum(t => t.Price);
    }
}