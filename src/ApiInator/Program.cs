using ApiInator.Infrastructure;

var builder =  WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>();

var app = builder.Build();

await app.RunAsync();