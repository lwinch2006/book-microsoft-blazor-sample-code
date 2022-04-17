namespace WasmHosted.Shared.Services;

public interface IApiClientFactory
{
    IApiClient Create();
}