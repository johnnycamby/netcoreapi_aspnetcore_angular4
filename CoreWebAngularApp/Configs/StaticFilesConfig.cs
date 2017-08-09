using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace CoreWebAngularApp.Configs
{
    public static class StaticFilesConfig
    {
        public static void StaticFileSetup(IApplicationBuilder app, IConfigurationRoot configurationRoot)
        {
            // Serve static files (html, css, js, images & more). See also the following URL:
            // https://docs.asp.net/en/latest/fundamentals/static-files.html for further reference.
            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = (context) =>
                {
                    // Disable caching for all static files.
                    context.Context.Response.Headers["Cache-Control"] = configurationRoot["StaticFiles:Header:Cache-Control"];
                    context.Context.Response.Headers["Pragma"] = configurationRoot["StaticFiles:Headers:Pragma"];
                    context.Context.Response.Headers["Expires"] = configurationRoot["StaticFiles:Headers:Expires"];
                }
            });
        }
    }
}