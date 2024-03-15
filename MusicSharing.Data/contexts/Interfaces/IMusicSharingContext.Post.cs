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
    public partial interface IMusicSharingContext
    {
        Task AddPost(Post post);

        Task AddComment(PostComment comment);

        Task<Post?> GetPost(int postId, bool withTracking);

        Task<IEnumerable<PostDto>> GetPostFeedForUser(int userId);

        Task<IEnumerable<string>> GetPostTitles();
    }
}
