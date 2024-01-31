using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using VideoGameHub.BuildingBlock.Web;
using VideoGameHub.JanusWrapper.Janus.Models;
using VideoGameHub.JanusWrapper.Janus.Services;

namespace VideoGameHub.JanusWrapper.Janus.Features.CreateSession;

public class CreateSession : IMinimalEndpoint
{
    public IEndpointRouteBuilder MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.CreateEndpoint<Session>(MinimalApiExtensions.EndpointType.Post, "janus", PostSession);
        return builder;
    }

    public async Task<IResult> PostSession(CreateSessionRequest request, IJanusClient janusClient)
    {
        var result =
            await janusClient.CreateSession(
                new Services.Models.CreateSessionRequest(request.Janus, request.Transaction));
        return Results.Ok(new Session(new Data(result.Data.Id), result.Janus, result.Transaction));
    }

    public record CreateSessionRequest(string Janus, string Transaction);
}