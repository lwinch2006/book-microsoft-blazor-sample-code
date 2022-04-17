using Microsoft.AspNetCore.Components;
using WasmHosted.Shared.Models;
using WasmHosted.Shared.ViewModels;
using WasmHosted.Shared.ViewModels.PizzaRestaurant;

namespace WasmHosted.Client.Components.PizzaRestaurant;

public partial class PizzaItem
{
    [Parameter]
    public PizzaVm? Pizza { get; set; }
    
    [Parameter]
    public string? ButtonTitle { get; set; }
    
    [Parameter]
    public string? ButtonClass { get; set; }
    
    [Parameter]
    public EventCallback<PizzaVm> Selected { get; set; }
    
    [Parameter]
    public Action<PizzaVm>? ShowPizzaInformation { get; set; }

    private string GetSpicinessImageUrl(SpicinessTypes spicinessTypes)
    {
        return $"images/{spicinessTypes.ToString().ToLower()}.jpg";
    }
}