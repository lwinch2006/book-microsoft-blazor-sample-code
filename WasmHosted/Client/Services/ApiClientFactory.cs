using ComponentsLibrary.Services;
using WasmHosted.Shared.Services;

namespace WasmHosted.Client.Services;

public class ApiClientFactory : IApiClientFactory
{
    private readonly HttpClient _httpClient;

    public ApiClientFactory(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public IApiClient Create()
    {
        return new ApiClient(_httpClient);
    }
}