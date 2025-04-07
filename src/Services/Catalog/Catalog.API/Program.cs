using Mapster;
using Marten;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddMapster();

builder.Services.AddMarten(
    options =>
    {
        options.Connection(builder.Configuration.GetConnectionString("Database")!);

    }).UseLightweightSessions();

var app = builder.Build();

// Configure the HTTP request pipeline

app.Run();