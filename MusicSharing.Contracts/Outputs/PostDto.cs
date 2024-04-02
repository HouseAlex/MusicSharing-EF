using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSharing.Contracts.Outputs
{
    /// <summary>
    /// This class represents a data transfer object (DTO) for a post.
    /// </summary>
    public class PostDto
    {
        /// <summary>
        /// The song artist's name.
        /// </summary>
        public string ArtistName { get; set; } = default!;

        /// <summary>
        /// The post title
        /// </summary>
        public string Caption { get; set; } = default!;

        /// <summary>
        /// The comment on the post.
        /// </summary>v
        public IEnumerable<CommentDto>? Comments { get; set; }

        /// <summary>
        /// The date of the post creation.
        /// </summary>v
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// The image url identifier.
        /// </summary>v
        public string ImageUrl { get; set; } = default!;

        /// <summary>
        /// The spotify user identifier.
        /// </summary>
        public string SpotifyId { get; set; } = default!;

        /// <summary>
        /// The spotify url identifier.
        /// </summary>v
        public string SpotifyUrl { get; set; } = default!;

        /// <summary>
        /// The track name of the post.
        /// </summary>
        public string TrackName { get; set; } = default!;


        /// <summary>
        /// The user's identifier.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The name of the user.
        /// </summary>
        public string UserName { get; set; } = default!;
    }
}
