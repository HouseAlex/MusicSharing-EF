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
        /// The title of the post.
        /// </summary>
        public string Title { get; set; } = default!;


        /// <summary>
        /// The user's identifier.
        /// </summary>
        public int userId { get; set; }

        /// <summary>
        /// The name of the user.
        /// </summary>
        public string userName { get; set; } = default!;
    }
}
