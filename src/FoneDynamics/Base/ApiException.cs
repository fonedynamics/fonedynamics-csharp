using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoneDynamics.Base
{
    /// <summary>
    /// Represents an exception that occurred during an API request.
    /// </summary>
    public class ApiException : Exception
    {
        /// <summary>
        /// The status code of the HTTP request.
        /// </summary>
        public int HttpStatusCode { get; private set; }
        /// <summary>
        /// The error code as per https://www.fonedynamics.com/docs/rest-api/errors/
        /// </summary>
        public string ErrorCode { get; private set; }

        /// <summary>
        /// Constructs a new ApiException.
        /// </summary>
        internal ApiException(int httpStatusCode, string errorCode, string message) : base(message)
        {
            // persist
            HttpStatusCode = httpStatusCode;
            ErrorCode = errorCode;
        }
    }
}
