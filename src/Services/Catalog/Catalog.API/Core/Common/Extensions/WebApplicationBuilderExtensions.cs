using Catalog.API.Extensions;

namespace Microsoft.AspNetCore.Builder;

public static class WebApplicationBuilderExtensions
{

    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddApplicationServices()
            .AddValidation()
            .AddMapsters()
            .AddApiDocumentation()  // Now properly returns IServiceCollection
            .AddMartenDb(builder.Configuration)
            .AddLocalizationSupport()
            .AddVersioning()
            .AddControllers();

        return builder;
    }
}