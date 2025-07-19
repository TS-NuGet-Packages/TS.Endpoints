using System.Reflection;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace TS.Endpoints;
public static class EndpointExtensions
{
    public static void AddEndpoint(this IServiceCollection services)
    {
        var assembly = Assembly.GetCallingAssembly();
        var modules = assembly.GetTypes()
            .Where(p => !p.IsInterface && !p.IsAbstract && typeof(IEndpoint).IsAssignableFrom(p));

        foreach (var module in modules)
        {
            services.AddTransient(typeof(IEndpoint), module);
        }
    }

    public static void AddEndpoint(this IServiceCollection services, params Assembly[] assemblies)
    {
        foreach (var assembly in assemblies)
        {
            var modules = assembly.GetTypes()
                .Where(p => !p.IsInterface && !p.IsAbstract && typeof(IEndpoint).IsAssignableFrom(p));

            foreach (var module in modules)
            {
                services.AddTransient(typeof(IEndpoint), module);
            }
        }
    }

    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
    {
        var modules = app.ServiceProvider.GetServices<IEndpoint>();
        foreach (var module in modules)
        {
            module.AddRoutes(app);
        }

        return app;
    }
}
