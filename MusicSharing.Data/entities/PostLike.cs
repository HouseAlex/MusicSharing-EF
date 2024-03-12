using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSharing.Data.entities
{
    /// <summary>
    /// A data object to track likes of a post
    /// </summary>
    [Table("postlike", Schema = "musicsharing")]
    public class PostLike
    {
        /// <summary>
        /// The post likes identifier.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// A boolean indicating whether the post like is active.
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// The post identifier.
        /// </summary>
        public int PostId { get; private set; }

        /// <summary>
        /// The identifier of user that liked the post.
        /// </summary>
        public int UserId { get; private set; }

        private PostLike() { }

        /// <summary>
        /// Creates a new instance of postlike.
        /// </summary>
        /// <param name="postId">The post identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The postlike object.</returns>
        public static PostLike Create(int postId, int userId)
        {
            return new PostLike 
            { 
                IsActive = true,
                PostId = postId, 
                UserId = userId 
            };
        }

        /// <summary>
        /// Deletes the postlike object.
        /// </summary>
        public void Delete()
        {
            this.IsActive = false;
        }
    }
}
