using Microsoft.EntityFrameworkCore;
using MusicSharing.Contracts.Outputs;

namespace MusicSharing.Business.Services.Interfaces;

/// <summary>
/// An interface for the user service.
/// </summary>
public interface IUserService
{
    //Task<MusicSharing.API.Controllers.InstagramPostDto> getPostInformation(string postId);
    Task<UserDto> GetUser(int id);
}