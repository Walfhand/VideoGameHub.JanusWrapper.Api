using VideoGameHub.BuildingBlock.Web;
using VideoGameHub.JanusWrapper;
using VideoGameHub.JanusWrapper.Janus.Config;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomCors("NoRestriction", "*");
builder.Services.AddJanus();
builder.Services.AddJanusWrapperEndpoints();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCustomCors("NoRestriction");
app.UseJanusWrapperEndpoints();
app.Run();