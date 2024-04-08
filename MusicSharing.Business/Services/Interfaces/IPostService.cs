using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicSharing.Business.Models;
using MusicSharing.Contracts.Outputs;
using MusicSharing.Contracts.Inputs;

/// <summary>
/// An interface for the post service.
/// </summary>
namespace MusicSharing.Business.Services.Interfaces
{
    public interface IPostService
    {
        /// <summary>
        /// Retrieves the post feed from the database to a user.
        /// </summary>
        /// <param name="userId">The id of the user retreiving that post feed.</param>
        Task<IEnumerable<PostDto>> GetPostFeed(int userId);

        /// <summary>
        /// Retrieves the information from a post.
        /// </summary>
        /// <param name="postId">The id of the post we retrieve information from.</param>
        Task<PostDto> GetPostInformation(string postId);

        /// <summary>
        /// Retrieves the all the post titles from the database to the user.
        /// </summary>
        Task<IEnumerable<string>> GetPostTitles();

        /// <summary>
        /// Enables the ability to generate posts asynchronously.
        /// </summary>
        /// <param name="postModel">The model in which we generate posts.</param>
        Task<PostDto> CreatePost(PostCreatePayload postModel);

        /// <summary>
        /// Enables the ability to create post comments asynchronously.
        /// </summary>
        /// <param name="commentModel">The model in which we create comments.</param>
        Task CreateComment(CommentCreatePayload commentModel);

        /// <summary>
        /// Lets a user like/unlike a post.
        /// </summary>
        /// <param name="postId">The post identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="isLiked">A value indicating if the user has </param>
        /// <returns>A boolean indicating liked.</returns>
        Task<bool> LikePost(int postId, int userId, bool isLiked);
    }
}
