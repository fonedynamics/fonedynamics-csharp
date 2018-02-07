using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string Path { get; private set; }

        /// <summary>
        /// Optional list of query string parameters.
        /// </summary>
        public List<KeyValuePair<string, string>> QueryParameters { get; private set; }

        /// <summary>
        /// Optional body of the request.
        /// </summary>
        public byte[] RequestBody { get; private set; }

        /// <summary>
        /// Optional content type of the request.
        /// </summary>
        public string ContentType { get; private set; }

        private string _accountSid;
        private string _token;

        /// <summary>
        /// Constructs a new request.
        /// </summary>
        internal Request(string path, string accountSid, string token)
        {
            // persist
            Path = path;
            _accountSid = accountSid;
            _token = token;
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
    }
}
