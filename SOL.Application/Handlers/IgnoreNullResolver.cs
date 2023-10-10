using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SOL.Application.Handlers
{
    public class IgnoreNullResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(
            MemberInfo member,
            MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (property.PropertyType == typeof(string) && !property.PropertyType.IsValueType)
            {
                property.ShouldSerialize = instance =>
                {
                    object propValue = property.ValueProvider.GetValue(instance);
                    return propValue != null;
                };
            }

            return property;
        }
    }
}
