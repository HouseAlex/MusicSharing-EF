using MusicSharing.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSharing.Data.entities
{

    [Table("postcomment", Schema = "musicsharing")]
    public class PostComment
    {
        /// <summary>
        /// The comment.
        /// </summary>
        public string Comment { get; private set; } = default!;

        /// <summary>
        /// The date the post comment was created on.
        /// </summary>
        public DateTime CreatedOn { get; private set; }

        /// <summary>
        /// The post comment identifier.
        /// </summary>
        [Key]
        public int Id { get; private set; }

        /// <summary>
        /// A boolean indicating whether the post comment is active.
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// The post identifier.
        /// </summary>
        
        public int PostId { get; private set; }

        /// <summary>
        /// The post object.
        /// </summary>
        public virtual Post Post { get; private set; } = default!;

        /// <summary>
        /// The user identifier of the commenter.
        /// </summary>
        public int UserId { get; private set; }

        
        /// <summary>
        /// The user.
        /// </summary>
        [ForeignKey("UserId")]
        public virtual User? User { get; private set; }

        private PostComment() { }

        /// <summary>
        /// Creates a new instance of postcomment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="postId">The post identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The postcomment object.</returns>
        public static PostComment Create(string comment, int postId, int userId)
        {
            return new PostComment
            {
                Comment = comment,
                CreatedOn = DateTime.Now,
                IsActive = true,
                PostId = postId,
                UserId = userId
            };
        }

        /// <summary>
        /// Updates the comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        public void Update(string comment)
        {
            if (string.IsNullOrEmpty(comment))
            {
                throw new ArgumentNullException(nameof(comment));
            }

            this.Comment = comment;
        }

        /// <summary>
        /// Deletes the instance.
        /// </summary>
        public void Delete()
        {
            IsActive = false;
        }
    }
}
