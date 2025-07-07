using System;
using System.Net;
using System.Text.Json;
using ToDoListAPI.Exceptions;

namespace ToDoListAPI.Middlewares;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment environment)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            // check if env is dev or prod and return the error.
            var response = environment.IsDevelopment()
            ? new ApiException(httpContext.Response.StatusCode, ex.Message, ex.StackTrace)
            : new ApiException(httpContext.Response.StatusCode, ex.Message, "Internal server error");


            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var json = JsonSerializer.Serialize(response, options);

            await httpContext.Response.WriteAsync(json);
        }
        
    }
}
