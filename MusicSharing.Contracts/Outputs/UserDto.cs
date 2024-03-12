using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MusicSharing.Contracts.Outputs
{
    /// <summary>
    /// The user data transfer object.
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// The user identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name.
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// The spotify account.
        /// </summary>
        public string SpotifyId { get; set; } = default!;
    }
}
