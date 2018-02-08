using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoneDynamics.Http
{
    /// <summary>
    /// Represents the response from a HTTP request.
    /// </summary>
    internal class HttpResponse
    {
        /// <summary>
        /// The status code of the response.
        /// </summary>
        internal int HttpStatusCode { get; private set; }
        /// <summary>
        /// The response body.
        /// </summary>
        internal byte[] Content { get; private set; }

        /// <summary>
        /// Constructs a new HttpResponse.
        /// </summary>
        internal HttpResponse(int httpStatusCode, byte[] content)
        {
            // persist
            HttpStatusCode = httpStatusCode;
            Content = content;
        }

        /// <summary>
        /// Returns the content as a string. Uses UTF8.
        /// </summary>
        internal string GetContentString()
        {
            return Encoding.UTF8.GetString(Content);
        }

        /// <summary>
        /// Gets whether the HttpStatusCode indicates success.  ie. whether it is 2xx.
        /// </summary>
        internal bool IsSuccess => HttpStatusCode >= 200 && HttpStatusCode < 300;
    }
}
