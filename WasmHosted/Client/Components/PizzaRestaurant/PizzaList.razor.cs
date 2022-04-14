using Microsoft.AspNetCore.Components;
using WasmHosted.Shared.ViewModels;
using WasmHosted.Shared.ViewModels.PizzaRestaurant;

namespace WasmHosted.Client.Components.PizzaRestaurant;

public partial class PizzaList
{
    [Parameter]
    public string? Title { get; set; }

    [Parameter] public IEnumerable<PizzaVm> Pizzas { get; set; } = Enumerable.Empty<PizzaVm>();
    
    [Parameter]
    public string? ButtonClass { get; set; }
    
    [Parameter]
    public string? ButtonTitle { get; set; }
    
    [Parameter]
    public EventCallback<PizzaVm> Selected { get; set; }
}