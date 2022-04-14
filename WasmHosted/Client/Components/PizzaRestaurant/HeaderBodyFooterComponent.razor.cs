using Microsoft.AspNetCore.Components;

namespace WasmHosted.Client.Components.PizzaRestaurant;

public partial class HeaderBodyFooterComponent
{
    [Parameter]
    public RenderFragment? Header { get; set; }
    
    [Parameter]
    public RenderFragment? Body { get; set; }

    [Parameter]
    public RenderFragment? Footer { get; set; }
}