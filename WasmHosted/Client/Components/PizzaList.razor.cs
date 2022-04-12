using Microsoft.AspNetCore.Components;
using WasmHosted.Shared.ViewModels;

namespace WasmHosted.Client.Components;

public partial class PizzaList
{
    [Parameter]
    public string? Title { get; set; }

    [Parameter] public IEnumerable<Pizza> Pizzas { get; set; } = Enumerable.Empty<Pizza>();
    
    [Parameter]
    public string? ButtonClass { get; set; }
    
    [Parameter]
    public string? ButtonTitle { get; set; }
    
    [Parameter]
    public EventCallback<Pizza> Selected { get; set; }
}