using System;
using Discord;
using Discord.WebSocket;
using SpArtBotVersion3;
namespace SpArtBotVersion3
{
    public class Startup
    {
        public void ConfigurationServices(IServiceCollection services)
        {

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
        {
            app.UseRouting();

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Bot work");
                });
            });
        }
    }
}
