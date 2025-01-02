using CatalogService.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddGrpc()
    .AddDataBase()
    .AddApplicationServices();

var app = builder.Build();

app.MapGrpcService<CatalogService.Services.CatalogService>();

app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. " +
        "To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();