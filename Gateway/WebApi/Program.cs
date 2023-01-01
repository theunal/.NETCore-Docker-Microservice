using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.ConfigureAppConfiguration((host, config) =>
    {
        var ocelotFile = "" + host.HostingEnvironment.EnvironmentName == "Development"
            ? "ocelot-dev.json"
            : "ocelot.json";
        config.AddJsonFile(ocelotFile, optional: false, reloadOnChange: true);
    });
builder.Services.AddOcelot(configuration);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
await app.UseOcelot();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
