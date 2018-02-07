using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoneDynamics.Rest.V2.Messaging
{
    /// <summary>
    /// Represents the direction of a message.
    /// </summary>
    public enum MessageDirection
    {
        /// <summary>
        /// The message is an outgoing message.
        /// </summary>
        Transmit,
        /// <summary>
        /// The message is an incoming message.
        /// </summary>
        Receive
    }
}
