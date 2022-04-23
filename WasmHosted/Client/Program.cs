using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Services;
using WasmHosted.Client;
using WasmHosted.Client.Services;
using WasmHosted.Shared.Redux.Stores;
using WasmHosted.Shared.Services;
using WasmHosted.Shared.ViewModels.PizzaRestaurant;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// builder.Services.AddHttpClient<IApiClient, ApiClient>(client =>
// {
//     client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
// });

builder.Services.AddScoped<IApiClientFactory, ApiClientFactory>();
builder.Services.AddScoped<ILocalStorage, LocalStorageWithModule>();
builder.Services.AddScoped<IFocusService, FocusService>();
builder.Services.AddScoped<LazyAssemblyLoader>();
builder.Services.AddSingleton<StateVm>();
builder.Services.AddFluxor(options =>
{
	options.ScanAssemblies(typeof(AppStore).Assembly);
});

await builder.Build().RunAsync();
