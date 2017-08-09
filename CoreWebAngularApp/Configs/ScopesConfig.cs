using CoreWebAngularApp.Services;
using CoreWebAngularApp.Services.Contracts;
using CoreWebAngularApp.Services.Mappings;
using CoreWebAngularApp.Services.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace CoreWebAngularApp.Configs
{
    public static class ScopesConfig
    {
        public static void ScopeSetup(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IXplicitRepository, XplicitRepository>();
            serviceCollection.AddTransient<IPropertyMappingService, PropertyMappingService>();
            serviceCollection.AddTransient<ITypeHelperService, TypeHelperService>();

            // used by 'UrlHelper' to get the context in which the action runs
            serviceCollection.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            // help generate uri(s) to an action
            serviceCollection.AddScoped<IUrlHelper, UrlHelper>(implementationFactory =>
            {
                var actionContext = implementationFactory.GetService<IActionContextAccessor>().ActionContext;
                return new UrlHelper(actionContext);
            });

        }
    }
}