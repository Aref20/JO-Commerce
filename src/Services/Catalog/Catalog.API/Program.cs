using Catalog.API.Application.Behaviors;
using FluentValidation;
using Mapster;
using Marten;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(cfg => {

    cfg.RegisterServicesFromAssembly(assembly);
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
}
);
builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddMapster();

builder.Services.AddMarten(
    options =>
    {
        options.Connection(builder.Configuration.GetConnectionString("Database")!);

    }).UseLightweightSessions();

builder.Services.AddControllers();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddSingleton<IStringLocalizerFactory, ResourceManagerStringLocalizerFactory>(); 

var app = builder.Build();
// Configure the HTTP request pipeline

var supportedCultures = new[]
{
    new CultureInfo("en"),
    new CultureInfo("ar"),
    // Add other cultures as needed
};

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

// Exception handling middleware
app.UseExceptionHandler(config =>
{
    config.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
        if (exception is ValidationException validationException)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            var errors = validationException.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(e => e.ErrorMessage).ToArray()
                );
            await context.Response.WriteAsJsonAsync(new { Errors = errors });
        }
    });
});

app.MapControllers();

app.Run();