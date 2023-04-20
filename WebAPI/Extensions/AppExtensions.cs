using WebAPI.Middlewares;

namespace WebAPI.Extensions;

public static class AppExtensions
{
    public static void useErrorHandlingMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorHandlerMiddleware>();
    }
}