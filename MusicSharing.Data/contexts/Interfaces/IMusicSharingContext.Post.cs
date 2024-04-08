using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicSharing.Contracts.Outputs;
using MusicSharing.Data.entities;
using MusicSharing.Data.Entities;

namespace MusicSharing.Data.Contexts.Interfaces
{
    /// <summary>
    /// A partial interface for the music sharing database context pertaining to posts.
    /// </summary>
    public partial interface IMusicSharingContext
    {
        /// <summary>
        /// Adds a post to the database.
        /// </summary>
        /// <param name="post">The post getting added.</param>
        Task<Post?> AddPost(Post post);

        /// <summary>
        /// Adds a comment to the database.
        /// </summary>
        /// <param name="comment">The comment getting added.</param>
        Task AddComment(PostComment comment);

        /// <summary>
        /// Adds a post like to the database.
        /// </summary>
        /// <param name="postLike">The post like object.</param>
        Task AddPostLike(PostLike postLike);

        /// <summary>
        /// Gets a post from the database.
        /// </summary>
        /// <param name="postId">The id of the post getting added.</param>
        /// <param name="withTracking">The option to add a post with or without tracking.</param>
        Task<Post?> GetPost(int postId, bool withTracking);

        /// <summary>
        /// Gets the post like object.
        /// </summary>
        /// <param name="postId">The post identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The post like object.</returns>
        Task<PostLike?> GetPostLike(int postId, int userId);

        /// <summary>
        /// Retrieves the post feed from the database to a user.
        /// </summary>
        /// <param name="userId">The id of the user retreiving that post feed.</param>
        Task<IEnumerable<PostDto>> GetPostFeedForUser(int userId);

        /// <summary>
        /// Retrieves the all the post titles from the database to the user.
        /// </summary>
        Task<IEnumerable<string>> GetPostTitles();
    }
}
