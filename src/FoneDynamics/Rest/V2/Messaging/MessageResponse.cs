using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoneDynamics.Rest.V2
{
    /// <summary>
    /// The response to a Message request.
    /// </summary>
    internal class MessageResponse
    {
        /// <summary>
        /// The message that was sent.
        /// </summary>
        public MessageResource Message { get; internal set; }
    }
}
