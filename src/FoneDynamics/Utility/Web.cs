using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FoneDynamics.Utility
{
    /// <summary>
    /// Functionality for encoding.
    /// </summary>
    internal static class Web
    {
        /// <summary>
        /// Returns the URL encoded string.
        /// </summary>
        internal static string UrlEncode(string str)
        {
            return WebUtility.UrlEncode(str);
        }

        /// <summary>
        /// Returns a query string, or null if query is null or empty.
        /// </summary>
        internal static string CompileQueryString(List<KeyValuePair<string, string>> query)
        {
            if (query == null || query.Count == 0) return null;
            StringBuilder sb = new StringBuilder("?");
            for (int i = 0; i < query.Count; i++)
            {
                if (i > 0) sb.Append("&");
                sb.Append($"{UrlEncode(query[i].Key)}={UrlEncode(query[i].Value)}");
            }
            return sb.ToString();
        }
    }
}
