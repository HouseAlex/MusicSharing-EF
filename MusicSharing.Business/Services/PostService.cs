using MusicSharing.Contracts.Outputs;

namespace MusicSharing.Business.Services
{
    // PostService.cs
    /// <summary>
    /// This class implements the post service and provides methods for obtaining post information.
    /// </summary>
    public class PostService : Interfaces.IPostService
    {
        public async Task<PostDto> GetPost(string postId)
        {
            return await GetPostInformation(postId);
        }

        public async Task<PostDto> GetPostInformation(string postId)
        {
            throw new NotImplementedException();
        }
    }
}
