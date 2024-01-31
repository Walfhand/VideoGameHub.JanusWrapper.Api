namespace VideoGameHub.JanusWrapper.Janus.Services.Models;

public record CreateSessionRequest(string Janus, string Transaction);

public record CreateSessionResponse(string Janus, string Transaction, Data Data);

public record AttachPluginRequest(string Janus, long SessionId , string Plugin, string Transaction);

public record AttachPluginResponse(string Janus, long Session_id, string Transaction, Data Data);

public record LongPoolingRequest(long SessionId, long Rid, int Maxev);

public record LongPoolingResponse(string Janus);
public record Data(long Id);