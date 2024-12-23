
using CatalogService.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddDbContext<CatalogDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapGrpcService<CatalogService.Services.CatalogService>();

app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. " +
        "To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();