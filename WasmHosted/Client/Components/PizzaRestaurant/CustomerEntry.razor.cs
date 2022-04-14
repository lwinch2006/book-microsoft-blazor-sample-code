using Microsoft.AspNetCore.Components;
using WasmHosted.Shared.ViewModels;
using WasmHosted.Shared.ViewModels.PizzaRestaurant;

namespace WasmHosted.Client.Components.PizzaRestaurant;

public partial class CustomerEntry
{
    private InputWatcher? _inputWatcher;
    
    [Parameter]
    public string? Title { get; set; }
    
    [Parameter]
    public CustomerVm? Customer { get; set; }
    
    [Parameter]
    public EventCallback ValidSubmit { get; set; }
    
    [Parameter]
    public EventCallback<CustomerVm> CustomerChanged { get; set; }

    private void FieldChanged(string fieldName)
    {
        CustomerChanged.InvokeAsync(Customer);
    }
}