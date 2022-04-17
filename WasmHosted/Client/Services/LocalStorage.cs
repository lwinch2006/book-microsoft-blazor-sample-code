using Microsoft.JSInterop;

namespace WasmHosted.Client.Services;

public interface ILocalStorage
{
    Task Init();
    Task<T?> GetProperty<T>(string key);
    Task SetProperty<T>(string key, T value);
    Task Watch<T>(DotNetObjectReference<T> objRef) where T : class;
}

public class LocalStorage : ILocalStorage
{
    private readonly IJSRuntime _jsRuntime;

    public LocalStorage(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public Task Init()
    {
        return Task.CompletedTask;
    }

    public async Task<T?> GetProperty<T>(string key)
    {
        try
        {
            return await _jsRuntime.InvokeAsync<T>("blazorLocalStorage.get", key);
        }
        catch (Exception e)
        {
            return default;
        }
    }

    public async Task SetProperty<T>(string key, T value)
    {
        await _jsRuntime.InvokeVoidAsync("blazorLocalStorage.set", key, value);
    }

    public async Task Watch<T>(DotNetObjectReference<T> objRef) where T : class
    {
        await _jsRuntime.InvokeVoidAsync("blazorLocalStorage.watch", objRef);
    }
}