using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FoneDynamics.Serialization
{
    /// <summary>
    /// Functionality for JSON serialisation.
    /// </summary>
    internal static class Json
    {
        /// <summary>
        /// Serializes the specified object as JSON.
        /// </summary>
        internal static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        /// <summary>
        /// Deserializes the specified JSON object specified as a string.
        /// </summary>
        internal static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
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
