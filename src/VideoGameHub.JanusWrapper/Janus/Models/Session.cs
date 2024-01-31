namespace VideoGameHub.JanusWrapper.Janus.Models;

public record Session(Data Data, string Janus, string Transaction);
public record Data(long Id);
