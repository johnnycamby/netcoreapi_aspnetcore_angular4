using System.Collections.Generic;
using CoreWebAngularApp.Services.Contracts;

namespace CoreWebAngularApp.Services.Mappings
{
    
    public class PropertyMapping<TSource, TDestination> : IPropertyMapping
    {
        public PropertyMapping(Dictionary<string, PropertyMappingValue> mappingDictionary)
        {
            MappingDictionary = mappingDictionary;
        }

        public Dictionary<string, PropertyMappingValue> MappingDictionary { get; private set; }
    }
}