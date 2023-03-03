using Microsoft.OpenApi.Models;
using System.Reflection;
using Swashbuckle.AspNetCore.Filters;
using CleanArchitecture.Api.Common.Mapping;

namespace CleanArchitecture.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddSwaggerService();
        services.AddOptions().AddControllers();
        services.AddMapping();

        return services;
    }

    private static IServiceCollection AddSwaggerService(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc(
                ApiInfo.Version,
                new OpenApiInfo
                {
                    Title = ApiInfo.Name,
                    Version = ApiInfo.Version,
                    Description = ApiInfo.Description
                });

            // Use XML code documentation in generating OpenApi sepc.
            var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));

            options.EnableAnnotations();
            options.ExampleFilters();
        });

        return services;
    }
}