using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using VideoGameHub.BuildingBlock.Web;

namespace VideoGameHub.JanusWrapper;

public static class EndpointConfiguration
{
    public static IServiceCollection AddJanusWrapperEndpoints(this IServiceCollection services)
    {
        services.AddMinimalEndpoints();
        return services;
    }

    public static void UseJanusWrapperEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapMinimalEndpoints();
    }
}