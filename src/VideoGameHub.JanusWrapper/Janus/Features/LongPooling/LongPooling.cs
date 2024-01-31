using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using VideoGameHub.BuildingBlock.Web;
using VideoGameHub.JanusWrapper.Janus.Services;
using VideoGameHub.JanusWrapper.Janus.Services.Models;

namespace VideoGameHub.JanusWrapper.Janus.Features.LongPooling;

public class LongPooling : IMinimalEndpoint
{
    public IEndpointRouteBuilder MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.CreateEndpoint<LongPoolingResponse>(MinimalApiExtensions.EndpointType.Get, "janus/{sessionId}", LongPoolingAsync);
        return builder;
    }

    public async Task<IResult> LongPoolingAsync(long sessionId, [AsParameters] LongPoolingRequest longPoolingRequest, IJanusClient janusClient, CancellationToken ct)
    {
        var result = await janusClient.LongPoolingAsync(longPoolingRequest with {SessionId = sessionId}, ct);
        return Results.Ok(result);
    }
}