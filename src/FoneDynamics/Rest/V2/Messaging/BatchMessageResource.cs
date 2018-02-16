using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FoneDynamics.Rest.V2
{
    /// <summary>
    /// A MessageResource also containing details of any errors occurred
    /// while processing the send request.
    /// </summary>
    public class BatchMessageResource : MessageResource
    {
        /// <summary>
        /// The error message associated with the failure.
        /// </summary>
        [JsonProperty(PropertyName = "Message")]
        public string ErrorMessage { get; internal set; }
        /// <summary>
        /// Gets whether sending the message was successful.
        /// If it failed, ErrorCode and ErrorMessage will be set containing details of the error.
        /// </summary>
        public bool Successful => MessageSid != null;

        internal BatchMessageResource() : base()
        {
        }
    }
}
