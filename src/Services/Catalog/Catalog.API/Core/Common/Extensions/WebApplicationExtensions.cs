using Catalog.API.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Scalar.AspNetCore;
using System.Globalization;

namespace Microsoft.AspNetCore.Builder;

public static class WebApplicationExtensions
{
    public static WebApplication ConfigureRequestPipeline(this WebApplication app)
    {
        app.UseRequestLocalization(ConfigureLocalization());
        app.UseCustomExceptionHandler();  // Using our new extension

        if (app.Environment.IsDevelopment())
        {
            app.MapScalarApiReference();
            app.MapOpenApi();
        }

        app.MapControllers();
        app.MapGet("/", () => Results.Redirect("/scalar"));

        return app;
    }

    private static RequestLocalizationOptions ConfigureLocalization()
    {
        var supportedCultures = new[]
        {
            new CultureInfo("en"),
            new CultureInfo("ar")
        };

        return new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture("en"),
            SupportedCultures = supportedCultures,
            SupportedUICultures = supportedCultures
        };
    }
}