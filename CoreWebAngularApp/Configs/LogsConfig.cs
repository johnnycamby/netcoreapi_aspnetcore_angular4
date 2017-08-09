using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoreWebAngularApp.Configs
{
    public static class LogsConfig
    {
        public static void Init(IApplicationBuilder builder, IHostingEnvironment hostingEnvironment, ILoggerFactory factory, IConfiguration configuration)
        {
            factory.AddConsole(configuration.GetSection("Logging"));
            factory.AddFile("logs/applogs-{Date}.json", isJson: true, minimumLevel: LogLevel.Trace);

            if (hostingEnvironment.IsDevelopment())
            {
                builder.UseDeveloperExceptionPage();
            }
            else
            {
                builder.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async ctx =>
                    {
                        var exceptionHandlerFeature = ctx.Features.Get<IExceptionHandlerFeature>();

                        if (exceptionHandlerFeature != null)
                        {
                            var logger = factory.CreateLogger("Global exception logger");
                            logger.LogError(500, exceptionHandlerFeature.Error, exceptionHandlerFeature.Error.Message);
                        }

                        ctx.Response.StatusCode = 500;
                        await ctx.Response.WriteAsync("An unexpected fault happed. Try again later");
                    });
                });
            }

          //  factory.AddDebug();

        }
    }
}