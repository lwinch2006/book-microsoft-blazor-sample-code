using WasmHosted.Server.Services;
using WasmHosted.Server.Services.PizzaRestaurant;

namespace WasmHosted.Server.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IMeasurementService, MeasurementService>();
        services.AddScoped<IMenuService, MenuService>();
        services.AddScoped<IOrdersService, OrdersService>();
        
        return services;
    }
}