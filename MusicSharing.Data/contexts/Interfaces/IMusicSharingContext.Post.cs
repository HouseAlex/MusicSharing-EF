using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicSharing.Contracts.Outputs;
using MusicSharing.Data.entities;

namespace MusicSharing.Data.Contexts.Interfaces
{
    public partial interface IMusicSharingContext
    {
        Task AddPost(Post post);

        Task<Post?> GetPost(int postId);

        Task<IEnumerable<PostDto>> GetPostFeedForUser(string spotifyId);

        Task<IEnumerable<string>> GetPostTitles();
    }
}
