using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoneDynamics.Rest.V2.Messaging
{
    /// <summary>
    /// The status of a message.
    /// </summary>
    public enum MessageStatus
    {
        /// <summary>
        /// The message has been received by Fone Dynamics and is being processed.
        /// </summary>
        Processing,
        /// <summary>
        /// The message has been submitted successfully to the SMS Center.
        /// </summary>
        Submitted,
        /// <summary>
        /// The message has been delivered successfully (if delivery receipts are activated).
        /// </summary>
        Delivered,
        /// <summary>
        /// The message has failed (submission to the SMS Center was not possible within a reasonable time limit).
        /// </summary>
        Failed,
        /// <summary>
        /// The message has been received (for inbound messages).
        /// </summary>
        Received
    }
}
