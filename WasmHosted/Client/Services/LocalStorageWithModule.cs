using Microsoft.JSInterop;

namespace WasmHosted.Client.Services;

public class LocalStorageWithModule : ILocalStorage
{
    private readonly IJSRuntime _jsRuntime;
    private IJSObjectReference? _jsObjectReference;
    
    public LocalStorageWithModule(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task Init()
    {
        _jsObjectReference ??=
            await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "/scripts/interopAsModule.js");
    }

    public async Task<T?> GetProperty<T>(string key)
    {
        try
        {
            return await _jsObjectReference!.InvokeAsync<T>("get", key);
        }
        catch (Exception e)
        {
            return default;
        }
    }

    public async Task SetProperty<T>(string key, T value)
    {
        await _jsObjectReference!.InvokeVoidAsync("set", key, value);
    }

    public async Task Watch<T>(DotNetObjectReference<T> objRef) where T : class
    {
        await _jsObjectReference!.InvokeVoidAsync("watch", objRef);
    }
}