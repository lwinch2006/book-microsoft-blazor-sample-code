using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace WasmHosted.Client.Services;

public interface IFocusService
{
    Task Focus(ElementReference elementReference);
}

public class FocusService : IFocusService
{
    private readonly IJSRuntime _jsRuntime;

    public FocusService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task Focus(ElementReference elementReference)
    {
        await _jsRuntime.InvokeVoidAsync("blazorFocus.set", elementReference);
    }
}