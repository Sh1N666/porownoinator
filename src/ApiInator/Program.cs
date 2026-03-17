using ApiInator.Application;
using ApiInator.Application.GGDealsApi;
using ApiInator.Application.HowLongToBeatApi;
using ApiInator.Application.SteamApi;
using Microsoft.AspNetCore.Mvc;
using SlimMessageBus.Host;
using SlimMessageBus.Host.Memory;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSingleton<ApplicationContext>(sp => new ApplicationContext(connectionString));

builder.Services.AddSlimMessageBus(mbb =>
{
    mbb
        .WithProviderMemory()
        .AutoDeclareFrom(typeof(Program).Assembly); 
});
builder.Services.AddGrpc();
builder.Services.AddSteamApi();
builder.Services.AddHLTBApi();
builder.Services.AddGgDealsApi();

var app = builder.Build();

app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });
app.MapGet("/status", ([FromServices]SteamApi steamApi) => "I'm Alive");

app.MapGrpcService<ApiInatorController>();

app.Run();