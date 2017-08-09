using System.Collections.Generic;
using CoreWebAngularApp.Services.Mappings;

namespace CoreWebAngularApp.Services.Contracts
{
    public interface IPropertyMappingService
    {
        Dictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>();
        bool ValidMappingExistsFor<TSource, TDestination>(string fields);
    }
}