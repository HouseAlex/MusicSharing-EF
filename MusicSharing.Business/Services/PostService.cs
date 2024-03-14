using MusicSharing.Business.Models;
using MusicSharing.Business.Services.Interfaces;
using MusicSharing.Contracts.Outputs;
using MusicSharing.Data.Contexts.Interfaces;

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

        public async Task<bool> CreatePost(PostCreateModel postModel)
        {
            try
            {
                var postEntity = new Post
                {
                    SpotifyId = postModel.SpotifyId,
                    UserId = postModel.UserId,
                    Title = postModel.Title,
                };

                context.Posts.Add(postEntity);
                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
