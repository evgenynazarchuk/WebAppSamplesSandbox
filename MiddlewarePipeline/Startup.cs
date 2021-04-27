using Microsoft.AspNetCore.Builder;

namespace MiddlewarePipeline
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.AddErrorMiddleware();
            app.AddAuthMiddleware();
            app.AddContentMiddleware();
        }
    }
}
