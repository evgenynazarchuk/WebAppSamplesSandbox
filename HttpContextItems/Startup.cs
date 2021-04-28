using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;

namespace HttpContextItems
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Use(async (ctx, next) =>
            {
                ctx.Items.TryAdd("key1", "value1");
                ctx.Items.TryAdd("key2", "value2");
                ctx.Items.TryAdd("key3", "value3");
                await next.Invoke();
            });

            app.UseMiddleware<ReadItemsMiddleware>();
        }
    }
}
