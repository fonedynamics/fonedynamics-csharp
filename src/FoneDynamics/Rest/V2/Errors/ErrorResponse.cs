using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoneDynamics.Http;

namespace FoneDynamics.Rest.V2.Errors
{
    /// <summary>
    /// Represents an error resource.
    /// </summary>
    internal class ErrorResponse
    {
        /// <summary>
        /// Information about the response.
        /// </summary>
        public ResponseStatus ResponseStatus { get; internal set; }

        /// <summary>
        /// Creates an exception from the provided response.
        /// </summary>
        internal static Exception CreateException(HttpResponse response)
        {
            // deserialise response
            ErrorResponse error = Utility.Json.Deserialize<ErrorResponse>(response.Content);
            // return exception
            return new Base.ApiException(response.HttpStatusCode, error.ResponseStatus.ErrorCode, error.ResponseStatus.Message);
        }
    }
}
