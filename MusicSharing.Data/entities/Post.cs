﻿using MusicSharing.Data.Entities;
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
        /// The song artist's name.
        /// </summary>
        public string ArtistName { get; private set; } = default!;

        /// <summary>
        /// The post title
        /// </summary>
        public string Caption { get; private set; } = default!;

        /// <summary>
        /// The post comments.
        /// </summary>
        public virtual ICollection<PostComment>? Comments { get; private set; }  

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

        /// <summary>
        /// The post likes.
        /// </summary>
        public virtual ICollection<PostLike>? Likes { get; private set; }


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
        /// The spotify redirect url for the post.
        /// </summary>
        public string SpotifyUrl { get; private set; } = default!;

        /// <summary>
        /// The track name.
        /// </summary>
        public string TrackName { get; private set; } = default!;

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
        /// <param name="trackName">The track name.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The created post object.</returns>
        public static Post Create(
            string artistName,
            string caption,
            string imageUrl, 
            string spotifyId,
            string spotifyUrl,
            string trackName, 
            int userId)

        {
            return new Post
            {
                ArtistName = artistName,
                Caption = caption,
                CreatedOn = DateTime.Now,
                ImageUrl = imageUrl,
                IsActive = true,
                SpotifyId = spotifyId,
                SpotifyUrl = spotifyUrl,
                TrackName = trackName,
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

            this.Caption = title;
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
