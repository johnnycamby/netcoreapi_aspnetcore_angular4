using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace CoreWebAngularApp.Configs
{
    public class Config
    {
        public static IConfigurationRoot Build(IHostingEnvironment hostingEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}