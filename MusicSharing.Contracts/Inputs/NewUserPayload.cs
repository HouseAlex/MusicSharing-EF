using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSharing.Contracts.Inputs
{
    /// <summary>
    /// A payload containing information for a new user.
    /// </summary>
    public class NewUserPayload
    {
        /// <summary>
        /// The user's name
        /// </summary>
        public string? Name { get; }

        /// <summary>
        /// The spotiy account.
        /// </summary>
        public string SpotifyAccount { get; } = default!;

        /// <summary>
        /// The spotify user identifier.
        /// </summary>
        public string SpotifyId { get; } = default!;
    }
}
