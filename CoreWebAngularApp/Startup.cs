using CoreWebAngularApp.Configs;
using CoreWebAngularApp.Data;
using CoreWebAngularApp.Dto;
using CoreWebAngularApp.Extensions;
using CoreWebAngularApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CoreWebAngularApp
{
    public class Startup
    {
        private readonly IConfigurationRoot _configurationRoot;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = Config.Build(hostingEnvironment);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            FormattersConfig.SetUp(services);
            DbConfig.DbSetUp(services, _configurationRoot);
            ScopesConfig.ScopeSetup(services);

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, XplicitDbContext xplicitDbContext)
        {
            LogsConfig.Init(app, env, loggerFactory, _configurationRoot);

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Company, CompanyDto>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CompanyName))
                    .ForMember(dest => dest.Lasted, opt => opt.MapFrom(src => src.FoundedAt.GetYears(src.PresentDate)));

                cfg.CreateMap<Car, CarDto>();
            });

            // Configure a rewrite rule to auto-lookup for standard default files such as index.html.
            app.UseDefaultFiles();

            // Deals with static files
            StaticFilesConfig.StaticFileSetup(app, _configurationRoot);




            xplicitDbContext.DataSeederContext();

            app.UseMvc();
        }

       
    }

    
}

