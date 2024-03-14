using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicSharing.Business.Models;
using MusicSharing.Contracts.Outputs;
using MusicSharing.Contracts.Inputs;

namespace MusicSharing.Business.Services.Interfaces
{
    public interface IPostService
    {
        Task<PostDto> GetPost(string postId);

        Task<PostDto> GetPostInformation(string postId);

        Task<IEnumerable<string>> GetPostTitles();

        Task CreatePost(PostCreatePayload postModel);
    }
}
