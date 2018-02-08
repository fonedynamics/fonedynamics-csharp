using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FoneDynamics.Utility
{
    /// <summary>
    /// Functionality for JSON serialisation.
    /// </summary>
    internal static class Json
    {
        /// <summary>
        /// Contract resolver to read/write non-public properties.
        /// </summary>
        class CustomResolver : DefaultContractResolver
        {
            private static CustomResolver _defaultInstance;

            internal static CustomResolver DefaultInstance
            {
                get
                {
                    if (_defaultInstance != null) return _defaultInstance;
                    return _defaultInstance = new CustomResolver();
                }
            }

            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var prop = base.CreateProperty(member, memberSerialization);
                if (member is PropertyInfo pi)
                {
                    prop.Writable = pi.SetMethod != null;
                }
                return prop;
            }
        }

        /// <summary>
        /// The content type for JSON text payloads: application/json
        /// </summary>
        internal const string CONTENT_TYPE = "application/json";

        /// <summary>
        /// Serializes the specified object as JSON.
        /// </summary>
        internal static string Serialize(object obj)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            return JsonConvert.SerializeObject(obj, Formatting.Indented, settings);
        }

        /// <summary>
        /// Deserializes the specified JSON object specified as a string.
        /// </summary>
        internal static T Deserialize<T>(string json)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = CustomResolver.DefaultInstance;
            return JsonConvert.DeserializeObject<T>(json, settings);
        }

        /// <summary>
        /// Deserializes the specified JSON object specified as a byte array.
        /// Assumes UTF8 encoding.
        /// </summary>
        internal static T Deserialize<T>(byte[] json)
        {
            string str = Encoding.UTF8.GetString(json);
            return Deserialize<T>(str);
        }
    }
}
