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

        public async Task<PostDto> GetPost(string postId)
        {
            return await GetPostInformation(postId);
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
            var newPost = Post.Create(payload.SpotifyId, payload.UserId, payload.Title);
            await context.CreatePost(newPost);
        }
    }
}
