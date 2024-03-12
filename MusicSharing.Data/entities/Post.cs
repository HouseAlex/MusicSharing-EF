using MusicSharing.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSharing.Data.entities
{
    /// <summary>
    /// The post object.
    /// </summary>
    [Table("post", Schema = "musicsharing")]
    public class Post
    {
        /// <summary>
        /// The post comments.
        /// </summary>
        public virtual ICollection<PostComment>? Comment { get; private set; }  // I forget how this is implemented fully might need to scratch this idea. but will research

        /// <summary>
        /// The date the post was created on.
        /// </summary>
        public DateTime CreatedOn { get; private set; }

        /// <summary>
        /// The post identifier.
        /// </summary>
        [Key]
        public int Id { get; private set; }

        /// <summary>
        /// The imageUrl for the post.
        /// </summary>
        public string ImageUrl { get; private set; } = default!;

        /// <summary>
        /// A boolean that indicates whether the post is active or not.
        /// </summary>
        public bool IsActive { get; private set; }

        /*
        /// <summary>
        /// The post type identifier
        /// </summary>
        public int PostTypeId {  get; private set; }    // Not sure if we will need this, depends on things the can be posted
        */

        /// <summary>
        /// The spotify identifier for the object posted.
        /// </summary>
        public string SpotifyId { get; private set; } = default!;

        /// <summary>
        /// The post title
        /// </summary>
        public string Title { get; private set; } = default!;

        /// <summary>
        /// The user identifer of the post creator
        /// </summary>
        public int UserId { get; private set; }

        /// <summary>
        /// The user.
        /// </summary>
        [ForeignKey("UserId")]
        public virtual User? User { get; private set; }

        private Post() { }

        /// <summary>
        /// Creates a new instance of post.
        /// </summary>
        /// <param name="imageUrl">The image url.</param>
        /// <param name="spotifyId">The spotify object identifier.</param>
        /// <param name="title">The post title.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The created post object.</returns>
        public static Post Create(string imageUrl, string spotifyId, string title, int userId)
        {
            return new Post
            {
                CreatedOn = DateTime.Now,
                ImageUrl = imageUrl,
                IsActive = true,
                SpotifyId = spotifyId,
                Title = title,
                UserId = userId
            };
        }

        /// <summary>
        /// Updates the post instance.
        /// </summary>
        /// <param name="title">The title.</param>
        public void Update(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(title));
            }

            this.Title = title;
        }

        /// <summary>
        /// Deletes the post instance.
        /// </summary>
        public void Delete()
        {
            IsActive = false;
        }

    }
}
