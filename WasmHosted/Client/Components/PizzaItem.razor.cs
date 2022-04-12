using Microsoft.AspNetCore.Components;
using WasmHosted.Shared.ViewModels;

namespace WasmHosted.Client.Components;

public partial class PizzaItem
{
    [Parameter]
    public Pizza? Pizza { get; set; }
    
    [Parameter]
    public string? ButtonTitle { get; set; }
    
    [Parameter]
    public string? ButtonClass { get; set; }
    
    [Parameter]
    public EventCallback<Pizza> Selected { get; set; }

    private string GetSpicinessImageUrl(SpicinessTypes spicinessTypes)
    {
        return $"images/{spicinessTypes.ToString().ToLower()}.jpg";
    }
}