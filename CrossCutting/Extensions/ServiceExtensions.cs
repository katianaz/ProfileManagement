using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace CrossCutting.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.EnableAnnotations();
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Profile Management API",
                Version = "v1",
                Description = "API for managing profiles and their access parameters"
            });
        });
        
        return services;
    }
}
