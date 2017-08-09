using System;
using System.Collections.Generic;
using System.Linq;
using CoreWebAngularApp.Dto;
using CoreWebAngularApp.Models;
using CoreWebAngularApp.Services.Contracts;

namespace CoreWebAngularApp.Services.Mappings
{

    public class PropertyMappingService : IPropertyMappingService
    {
        private readonly IList<IPropertyMapping> _propertyMappings = new List<IPropertyMapping>();

        // Resource property may map to multiple properties on underlying objects
        // a mapping may require reversing the sort order. E.g soting ascending by 'Lasted' maps to 
        // sorting descending by 'FoundedAt' thus introduction of a 'Revert'property
        private readonly Dictionary<string, PropertyMappingValue> _companyPropertyMapping = new Dictionary<string, PropertyMappingValue>
        {
            { "Id", new PropertyMappingValue(new List<string>(){"Id"})}, 
            { "Lasted", new PropertyMappingValue(new List<string>(){"FoundedAt"}, true)}, 
            { "Name", new PropertyMappingValue(new List<string>(){"CompanyName"})}, 
            { "Overview", new PropertyMappingValue(new List<string>(){"Overview"})}, 
        };

        public PropertyMappingService()
        {
            _propertyMappings.Add(new PropertyMapping<CompanyDto, Company>(_companyPropertyMapping));
        }

        public Dictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>()
        {
            var matchingMapping = _propertyMappings.OfType<PropertyMapping<TSource, TDestination>>();

            if (matchingMapping.Count() == 1)
            {
                return matchingMapping.First().MappingDictionary;
            }

            throw new Exception($"Cannot find exact property mapping instance for <{typeof(TSource)}, {typeof(TDestination)}>");
        }

        // Deals with sorting validity
        public bool ValidMappingExistsFor<TSource, TDestination>(string fields)
        {
            var propertyMapping = GetPropertyMapping<TSource, TDestination>();

            if (string.IsNullOrWhiteSpace(fields))
            {
                return true;
            }

            var fieldsAfterSplit = fields.Split(',');

            foreach (var field in fieldsAfterSplit)
            {
                var trimmedField = field.Trim();
                var indexOfFirstSpace = trimmedField.IndexOf(" ", StringComparison.OrdinalIgnoreCase);
                var propertyName = indexOfFirstSpace == -1 ? trimmedField : trimmedField.Remove(indexOfFirstSpace);

                if (!propertyMapping.ContainsKey(propertyName))
                {
                    return false;
                }
            }

            return true;
        }
    }
}