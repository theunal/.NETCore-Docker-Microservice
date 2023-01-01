var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGrpcService<WebApi.GrpcServices.DenemeService>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
