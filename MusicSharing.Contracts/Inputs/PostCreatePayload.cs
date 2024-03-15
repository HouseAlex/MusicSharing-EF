using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSharing.Contracts.Inputs
{
    /// <summary>
    /// A payload containing information needed to create a new post.
    /// </summary>
    public class PostCreatePayload
    {
        /// <summary>
        /// The image url identifier.
        /// </summary>
        public string ImageURL { get; } = default!;

        /// <summary>
        /// The spotify user identifier.
        /// </summary>
        public string SpotifyId { get; } = default!;

        /// <summary>
        /// The title of the post.
        /// </summary>
        public string Title { get; } = default!;

        /// <summary>
        /// The user's identifier.
        /// </summary>
        public int UserId { get; } = default!;
    }
}
