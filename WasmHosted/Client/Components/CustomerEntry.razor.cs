using Microsoft.AspNetCore.Components;
using WasmHosted.Shared.ViewModels;

namespace WasmHosted.Client.Components;

public partial class CustomerEntry
{
    private InputWatcher? _inputWatcher;
    
    [Parameter]
    public string? Title { get; set; }
    
    [Parameter]
    public Customer? Customer { get; set; }
    
    [Parameter]
    public EventCallback ValidSubmit { get; set; }
    
    [Parameter]
    public EventCallback<Customer> CustomerChanged { get; set; }

    private void FieldChanged(string fieldName)
    {
        CustomerChanged.InvokeAsync(Customer);
    }
}