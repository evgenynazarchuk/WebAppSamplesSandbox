using Microsoft.AspNetCore.Builder;

namespace MiddlewarePipeline
{
    public static class MiddlewareExt
    {
        public static IApplicationBuilder AddAuthMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<AuthMiddleware>();
            return app;
        }

        public static IApplicationBuilder AddErrorMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorMiddleware>();
            return app;
        }

        public static IApplicationBuilder AddContentMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ContentMiddleware>();
            return app;
        }
    }
}
