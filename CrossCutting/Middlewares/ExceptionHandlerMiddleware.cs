using CrossCutting.Error;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace CrossCutting.Middlewares;

public class ExceptionHandlerMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ErrorCode.GetStatusCode(ErrorType.InternalServerError);
            await context.Response.WriteAsync(JsonSerializer.Serialize(ErrorMessage.GetMessage(ErrorType.InternalServerError)));
        }
    }
}