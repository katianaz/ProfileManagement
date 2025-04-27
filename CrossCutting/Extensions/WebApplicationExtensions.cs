using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace CrossCutting.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseSwaggerDevelopment(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Profile Management");
            });
        }

        return app;
    }
}
