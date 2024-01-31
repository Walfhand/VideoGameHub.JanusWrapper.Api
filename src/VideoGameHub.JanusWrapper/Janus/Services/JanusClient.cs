using System.Net.Http.Json;
using System.Text.Json;
using VideoGameHub.JanusWrapper.Janus.Services.Models;

namespace VideoGameHub.JanusWrapper.Janus.Services;

public class JanusClient : IJanusClient
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _jsonOptions;
    
    public JanusClient(HttpClient client)
    {
        _client = client;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }
    public async Task<CreateSessionResponse> CreateSession(CreateSessionRequest request)
    {
        var response = await _client.PostAsJsonAsync("janus", request, _jsonOptions);
        var responseContent = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<CreateSessionResponse>(responseContent, _jsonOptions);
        return result!;
    }

    public async Task<AttachPluginResponse> AttachPluginAsync(AttachPluginRequest request, CancellationToken ct)
    {
        var response = await _client.PostAsJsonAsync($"janus/{request.SessionId}", request, _jsonOptions, ct);
        var responseContent = await response.Content.ReadAsStringAsync(ct);
        var result = JsonSerializer.Deserialize<AttachPluginResponse>(responseContent, _jsonOptions);
        return result!;
    }

    public async Task<LongPoolingResponse[]> LongPoolingAsync(LongPoolingRequest request, CancellationToken ct)
    {
        var response = await _client.GetFromJsonAsync<LongPoolingResponse[]>($"janus/{request.SessionId}?rid={request.Rid}&maxev={request.Maxev}", _jsonOptions, ct);
        return response!;
    }
}