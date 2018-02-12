using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoneDynamics.Extensions
{
    /// <summary>
    /// Extension methods for dealing with Unix dates.
    /// </summary>
    public static class UnixDateExtensions
    {
        /// <summary>
        /// The Unix epoch.
        /// </summary>
        private static DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Converts the specified time to Unix time.
        /// </summary>
        public static long ToUnixTime(this DateTime date)
        {
            return (long)date.Subtract(_epoch).TotalSeconds;
        }

        /// <summary>
        /// Converts the specified Unix time to a DateTime.
        /// </summary>
        public static DateTime FromUnixTime(this long unixTime)
        {
            return _epoch.AddSeconds(unixTime);
        }
    }
}
