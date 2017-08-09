using System.Linq;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace CoreWebAngularApp.Configs
{
    public static class FormattersConfig
    {
        public static void SetUp(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMvc(setupAction =>
            {
                // For request header 'application/json' or 'application/xml' : 406 Not acceptable
                setupAction.ReturnHttpNotAcceptable = true;
                setupAction.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());

                var xmlDataContractSerialiserInputFormatter = new XmlDataContractSerializerInputFormatter();
                xmlDataContractSerialiserInputFormatter.SupportedMediaTypes.Add("application/vnd.johnny.companywithLasted.full+xml");
                // deals with 415 unsupported media type
                setupAction.InputFormatters.Add(xmlDataContractSerialiserInputFormatter);

                var jsonInputFormatter = setupAction.InputFormatters.OfType<JsonInputFormatter>().FirstOrDefault();

                if (jsonInputFormatter != null)
                {
                    jsonInputFormatter.SupportedMediaTypes.Add("application/vnd.johnny.company.full+json");
                    jsonInputFormatter.SupportedMediaTypes.Add("application/vnd.johnny.companywithLasted.full+json");
                }

                var jsonOutputFormatter = setupAction.OutputFormatters.OfType<JsonOutputFormatter>().FirstOrDefault();
                jsonOutputFormatter?.SupportedMediaTypes.Add("application/vnd.johnny.hateoas+json");
            })
            .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
        }
    }
}