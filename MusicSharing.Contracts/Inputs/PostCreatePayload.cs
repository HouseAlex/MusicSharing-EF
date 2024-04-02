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
        /// The song artist's name.
        /// </summary>
        public string ArtistName { get; set; } = default!;

        /// <summary>
        /// The caption of the post.
        /// </summary>
        public string Caption { get; set; } = default!;

        /// <summary>
        /// The image url.
        /// </summary>
        public string ImageUrl { get; set; } = default!;

        /// <summary>
        /// The spotify user identifier.
        /// </summary>
        public string SpotifyId { get; set; } = default!;

        /// <summary>
        /// The spotify url.
        /// </summary>
        public string SpotifyUrl { get; set; } = default!;

        /// <summary>
        /// The track's name.
        /// </summary>
        public string TrackName { get; set; } = default!;

        /// <summary>
        /// The user's identifier.
        /// </summary>
        public int UserId { get; set; } = default!;
    }
}
