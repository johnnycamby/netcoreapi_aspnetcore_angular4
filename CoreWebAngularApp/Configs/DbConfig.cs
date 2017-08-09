using CoreWebAngularApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreWebAngularApp.Configs
{
    public static class DbConfig
    {
        public static void DbSetUp(IServiceCollection serviceCollection, IConfigurationRoot configurationRoot)
        {
            serviceCollection.AddDbContext<XplicitDbContext>(
                options => options.UseSqlServer(configurationRoot.GetConnectionString("coreAngApp")));
        }
    }
}