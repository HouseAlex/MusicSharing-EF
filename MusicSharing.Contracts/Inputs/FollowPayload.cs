using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSharing.Contracts.Inputs
{
    public class FollowPayload
    {
        /// <summary>
        /// The user name of who to follow.
        /// </summary>
        public string FollowUserName { get; set; } = default!;

        /// <summary>
        /// The user identifier.
        /// </summary>
        public int UserId { get; set; }
    }
}
