using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using VideoGameHub.BuildingBlock.Web;
using VideoGameHub.JanusWrapper.Janus.Services;
using VideoGameHub.JanusWrapper.Janus.Services.Models;

namespace VideoGameHub.JanusWrapper.Janus.Features.AttachPlugin;

public class AttachPlugin : IMinimalEndpoint
{
    public IEndpointRouteBuilder MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.CreateEndpoint<AttachPluginResponse>(MinimalApiExtensions.EndpointType.Post, "janus/{sessionId}", AttachPluginAysnc);
        return builder;
    }

    public async Task<IResult> AttachPluginAysnc(long sessionId, AttachPluginRequest attachPluginRequest, IJanusClient janusClient, CancellationToken ct)
    {
        var result = await janusClient.AttachPluginAsync(attachPluginRequest with {SessionId = sessionId}, ct);
        return Results.Ok(result);
    }
}