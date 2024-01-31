using Microsoft.Extensions.DependencyInjection;
using VideoGameHub.JanusWrapper.Janus.Services;

namespace VideoGameHub.JanusWrapper.Janus.Config;

public static class JanusConfiguration
{
    public static IServiceCollection AddJanus(this IServiceCollection services)
    {
        services.AddScoped<IJanusClient, JanusClient>();
        services.AddHttpClient<IJanusClient, JanusClient>(client =>
        {
            client.BaseAddress = new Uri("http://janus-gateway:8088/");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        });
        return services;
    }
}