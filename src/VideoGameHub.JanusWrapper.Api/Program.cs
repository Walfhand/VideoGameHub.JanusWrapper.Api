using VideoGameHub.BuildingBlock.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomCors("NoRestriction", "*");
builder.Services.AddMinimalEndpoints();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCustomCors("NoRestriction");
app.MapMinimalEndpoints();
app.Run();