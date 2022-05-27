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

    public static IServiceCollection AddAuthenticationServices(this IServiceCollection services)
    {
        services
            .AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.RequireHttpsMetadata = false;
                options.Authority = "https://localhost:5011";
                options.Audience = "blazor-book-hosted-app-api";
            });
        
        return services;
    }

    public static IServiceCollection AddAuthorizationServices(this IServiceCollection services)
    {
        services
            .AddAuthorization(options =>
            {
                options.AddPolicy("read-access", policy => policy.RequireClaim("scope", "blazor-book-hosted-app-api.read"));
                options.AddPolicy("write-access", policy => policy.RequireClaim("scope", "blazor-book-hosted-app-api.write"));
            });

        return services;
    }
}