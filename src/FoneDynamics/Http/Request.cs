using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoneDynamics.Utility;

namespace FoneDynamics.Http
{
    /// <summary>
    /// Describes a request to an external endpoint.
    /// </summary>
    internal class Request
    {
        /// <summary>
        /// Platform version and details string to use in the User-Agent.
        /// </summary>
        private const string PLATFORM = ".NET (.NET Framework 4.5+)";
        /// <summary>
        /// The hostname of the API.
        /// </summary>
        private const string API_HOST = "api.fonedynamics.com";

        /// <summary>
        /// The path to make the request to.
        /// </summary>
        internal string Path { get; private set; }

        /// <summary>
        /// Optional list of query string parameters.
        /// </summary>
        internal List<KeyValuePair<string, string>> QueryParameters { get; private set; }

        /// <summary>
        /// The HTTP method to use for the request.
        /// </summary>
        internal HttpMethod Method { get; private set; }

        /// <summary>
        /// Optional body of the request.
        /// </summary>
        internal byte[] RequestBody { get; private set; }

        /// <summary>
        /// Optional content type of the request.
        /// </summary>
        internal string ContentType { get; private set; }

        /// <summary>
        /// The AccountSid to use for this request.
        /// </summary>
        internal string AccountSid { get; private set; }

        /// <summary>
        /// The token to use for this request.
        /// </summary>
        internal string Token { get; private set; }

        /// <summary>
        /// Constructs a new request.
        /// </summary>
        internal Request(HttpMethod method, string path, string accountSid, string token)
        {
            // persist
            Method = method;
            Path = path;
            AccountSid = accountSid;
            Token = token;
        }

        /// <summary>
        /// Adds a new query parameter to the request.
        /// </summary>
        internal void AddQueryParameter(string key, string value)
        {
            if (QueryParameters == null) QueryParameters = new List<KeyValuePair<string, string>>();
            QueryParameters.Add(new KeyValuePair<string, string>(key, value));
        }

        /// <summary>
        /// Sets the body of the request.
        /// </summary>
        internal void SetBody(byte[] requestBody, string contentType)
        {
            RequestBody = requestBody;
            ContentType = contentType;
        }

        /// <summary>
        /// Sets the body of the request. The request body will be encoded as UTF8.
        /// </summary>
        internal void SetBody(string requestBody, string contentType)
        {
            RequestBody = Encoding.UTF8.GetBytes(requestBody);
            ContentType = contentType;
        }

        /// <summary>
        /// Returns the URI for this request.
        /// </summary>
        internal string CreateUri()
        {
            return $"https://{API_HOST}{Path}{Web.CompileQueryString(QueryParameters)}";
        }
    }
}
