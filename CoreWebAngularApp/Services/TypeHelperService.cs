using System;
using System.Reflection;
using CoreWebAngularApp.Services.Contracts;

namespace CoreWebAngularApp.Services
{
    // For a give string of fields all properties matching those fields exist on a given type
    public class TypeHelperService : ITypeHelperService
    {
        public bool TypeHasProperty<T>(string fields)
        {
            if (string.IsNullOrWhiteSpace(fields))
            {
                return true;
            }

            var fieldsAfterSplit = fields.Split(',');

            foreach (var field in fieldsAfterSplit)
            {
                var propertyName = field.Trim();
                var propertyInfo = typeof(T).GetProperty(propertyName,
                    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                if (propertyInfo == null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}