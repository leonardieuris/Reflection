using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppReflection
{
    public static class RenameAttributeUtility
    {

        private class PropertyInfoExtended
        {
            public PropertyInfo PropertyInfo { get; set; }
            public RenameAttribute Attribute { get; set; }
        }

        private static readonly Dictionary<Type, PropertyInfoExtended[]> PropertyInfos = new Dictionary<Type, PropertyInfoExtended[]>();


        public static Dictionary<string, object> GetAttributeValues(Person obj)
        {
            var propertyInfos = GetProperties(obj.GetType());
            return propertyInfos.ToDictionary(propertyInfo => propertyInfo.Attribute.AttributeName, propertyInfo => propertyInfo.PropertyInfo.GetValue(obj));
        }



        private static PropertyInfoExtended[] GetProperties(Type type)
        {
            var found = PropertyInfos.TryGetValue(type, out var propertyInfoExtended);
            if (found)
                return propertyInfoExtended;

            propertyInfoExtended = type
                .GetProperties()
                .Select(ExtendWithAttributeName)
                .Where(_ => _ != null)
                .ToArray();

            PropertyInfos.Add(type, propertyInfoExtended);
            return propertyInfoExtended;
        }

        private static PropertyInfoExtended ExtendWithAttributeName(PropertyInfo pi)
        {
            var attribute = pi.GetCustomAttributes(true)
                            .FirstOrDefault(a => a is RenameAttribute);
            if (attribute != null)
                return new PropertyInfoExtended
                {
                    PropertyInfo = pi,
                    Attribute = attribute as RenameAttribute
                };
            return null;
        }
    }
}