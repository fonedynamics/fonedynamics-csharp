using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoneDynamics
{
    /// <summary>
    /// The Fone Dynamics client.
    /// </summary>
    public sealed class FoneDynamicsClient
    {
        private const string EX_NOT_INITIALIZED = "FoneDynamicsClient has not been initialized. Call Initialize() or configure app settings.";
        private static FoneDynamicsClient _defaultInstance;
        private string _accountSid;
        private string _token;
        private string _defaultPropertySid;

        /// <summary>
        /// Constructs a new FoneDynamicsClient.
        /// </summary>
        /// <param name="accountSid">The AccountSid that represents the account you are using.</param>
        /// <param name="token">A token associated with the account.</param>
        /// <param name="defaultPropertySid">The PropertySid to use in applicable requests where no PropertySid is specified.</param>
        public FoneDynamicsClient(string accountSid, string token, string defaultPropertySid = null)
        {
            // persist
            _accountSid = accountSid;
            _token = token;
            _defaultPropertySid = defaultPropertySid;
        }

        /// <summary>
        /// The default instance of FoneDynamicsClient.
        /// </summary>
        internal static FoneDynamicsClient DefaultInstance
        {
            get
            {
                if (_defaultInstance != null) return _defaultInstance;
                return _defaultInstance = CreateInstance(ConfigurationManager.AppSettings["FoneDynamics.AccountSid"],
                    ConfigurationManager.AppSettings["FoneDynamics.Token"],
                    ConfigurationManager.AppSettings["FoneDynamics.DefaultPropertySid"]);
            }
        }

        /// <summary>
        /// Creates a default instance using the specified parameters.
        /// </summary>
        private static FoneDynamicsClient CreateInstance(string accountSid, string token, string defaultPropertySid)
        {
            // validate
            if (accountSid == null || token == null) throw new Exception(EX_NOT_INITIALIZED);

            // create and return the instance
            return new FoneDynamicsClient(accountSid, token, defaultPropertySid);
        }

        /// <summary>
        /// Initializes the default FoneDynamicsClient.
        /// </summary>
        /// <param name="accountSid">The AccountSid that represents the account you are using.</param>
        /// <param name="token">A token associated with the account.</param>
        /// <param name="defaultPropertySid">The PropertySid to use in applicable requests where no PropertySid is specified.</param>
        public static void Initialize(string accountSid, string token, string defaultPropertySid = null)
        {
            // set the default instance
            _defaultInstance = CreateInstance(accountSid, token, defaultPropertySid);
        }

        /// <summary>
        /// The default PropertySid to use for requests where a PropertySid is not specified.
        /// </summary>
        internal static string DefaultPropertySid
        {
            get
            {
                return DefaultInstance?._defaultPropertySid;
            }
        }
    }
}
