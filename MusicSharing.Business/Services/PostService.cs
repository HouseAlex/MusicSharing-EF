using MusicSharing.Business.Models;
using MusicSharing.Business.Services.Interfaces;
using MusicSharing.Contracts.Outputs;
using MusicSharing.Data.Contexts.Interfaces;
using MusicSharing.Contracts.Inputs;
using MusicSharing.Data.entities;

namespace MusicSharing.Business.Services
{
    /// <summary>
    /// This class implements the post   service and provides methods for obtaining post information.
    /// </summary>
    public class PostService : IPostService
    {
        private readonly IMusicSharingContext context;

        public PostService(IMusicSharingContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets the post based on the identifier.
        /// </summary>
        /// <param name="postId">The post identifier.</param>
        /// <returns>The post object.</returns>
        public async Task<PostDto> GetPost(string postId)
        {
            return await GetPostInformation(postId);
        }

        /// <summary>
        /// Gets the post feed for the user.
        /// </summary>
        /// <param name="spotifyId"></param>
        /// <returns>A list of posts.</returns>
        public async Task<IEnumerable<PostDto>> GetPostFeed(string spotifyId)
        {
            return await context.GetPostFeedForUser(spotifyId);
        }

        public async Task<PostDto> GetPostInformation(string postId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<string>> GetPostTitles()
        {
            var postTitles = await context.GetPostTitles();

            return postTitles;
        }

        public async Task CreatePost(PostCreatePayload payload)
        {
            var newPost = Post.Create(payload.ImageURL, payload.SpotifyId, payload.Title, payload.UserId);
            await context.CreatePost(newPost);
        }
    }
}
