using Catalog.API.Core.Interfaces;
using Catalog.API.Features.Attributes;
using Catalog.API.Features.Brands;
using Catalog.API.Features.Categories;
using Catalog.API.Features.Products;
using Catalog.API.Features.Tags;
using Catalog.API.Features.TaxClasses;
using Catalog.API.Features.TaxRates;
using FluentValidation;
using Mapster;
using Marten;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Localization;

namespace Catalog.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ITagService, TagService>();
        services.AddScoped<ITaxClassService, TaxClassService>();
        services.AddScoped<ITaxRateService, TaxRateService>();
        services.AddScoped<IAttributeService, AttributeService>();
        return services;
    }

    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(Program).Assembly);
        return services;
    }

    public static IServiceCollection AddMartenDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMarten(options =>
        {
            options.Connection(configuration.GetConnectionString("Database")!);
        })
            .UseLightweightSessions();

        return services;
    }

    public static IServiceCollection AddLocalizationSupport(this IServiceCollection services)
    {
        services.AddLocalization(options => options.ResourcesPath = "Resources");
        services.AddSingleton<IStringLocalizerFactory, ResourceManagerStringLocalizerFactory>();
        return services;
    }

    public static IServiceCollection AddApiDocumentation(this IServiceCollection services)
    {
        services.AddOpenApi();
        return services;
    }

    public static IServiceCollection AddMapsters(this IServiceCollection services)
    {
        services.AddMapster();
        return services;
    }

    public static IServiceCollection AddVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0); // Default to v1.0
            options.ReportApiVersions = true; // Adds API version headers in responses

            // Choose how you want to read the version
            options.ApiVersionReader = ApiVersionReader.Combine(
                new QueryStringApiVersionReader("api-version")// e.g. ?api-version=1.0
            );
        });
        return services;
    }


}