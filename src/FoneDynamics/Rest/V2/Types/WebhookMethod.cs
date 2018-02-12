using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoneDynamics.Rest.V2
{
    /// <summary>
    /// The method to use for webhooks.
    /// </summary>
    public enum WebhookMethod
    {
        /// <summary>
        /// Webhooks should use POST.
        /// </summary>
        Post,
        /// <summary>
        /// Webhooks should use GET.
        /// </summary>
        Get
    }
}
