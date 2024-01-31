
using VideoGameHub.JanusWrapper.Janus.Services.Models;

namespace VideoGameHub.JanusWrapper.Janus.Services;

public interface IJanusClient
{
    Task<CreateSessionResponse> CreateSession(CreateSessionRequest request); 
    Task<AttachPluginResponse> AttachPluginAsync(AttachPluginRequest request, CancellationToken ct);
    Task<LongPoolingResponse[]> LongPoolingAsync(LongPoolingRequest request, CancellationToken ct);
}