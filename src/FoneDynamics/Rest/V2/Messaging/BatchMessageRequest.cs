using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoneDynamics.Rest.V2
{
    /// <summary>
    /// The request to a BatchMessage.
    /// </summary>
    internal class BatchMessageRequest
    {
        /// <summary>
        /// The messages to be sent.
        /// </summary>
        public IEnumerable<MessageResource> Messages { get; internal set; }

        /// <summary>
        /// Constructs a new BatchMessageRequest with the specified messages.
        /// </summary>
        internal BatchMessageRequest(IEnumerable<MessageResource> messages)
        {
            // persist
            Messages = messages;
        }
    }
}
