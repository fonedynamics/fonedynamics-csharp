using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoneDynamics.Rest.V2.Errors
{
    /// <summary>
    /// The ResponseStatus object.
    /// </summary>
    internal class ResponseStatus
    {
        /// <summary>
        /// The error code associated with the response status.
        /// </summary>
        public string ErrorCode { get; internal set; }
        /// <summary>
        /// The message associated with the error code.
        /// </summary>
        public string Message { get; internal set; }
    }
}
