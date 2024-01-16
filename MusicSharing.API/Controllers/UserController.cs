using Microsoft.AspNetCore.Mvc;
using MusicSharing.Buisness.Services.Interfaces;
using MusicSharing.Contracts.Outputs;


namespace MusicSharing.API.Controllers;

/// <summary>
/// The controller for user information.
/// </summary>
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService userService; 

    /// <summary>
    /// The instance of the user controller.
    /// </summary>
    /// <param name="userService">The user service</param>
    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    /// <summary>
    /// Placeholder function to show the process.
    /// </summary>
    /// <returns>An emtpy task</returns>
    [HttpGet("{Id}")]
    public async Task<UserDto> GetUser(int id)
    {
        return await userService.GetUser(id);
    }

}

    /// <summary>
    /// This class creates the relationship between the InstagramDto and our
    /// instagram services.
    /// </summary>
    public class InstagramDto : instagramService
    {
        private readonly InstagramService instagramService;
        public InstagramDto(InstagramService instagramService)
        {
            this.instagramService = instagramService;
        }
    }

    /// <summary>
    /// This interface provides a contract for the class to the implement.
    /// </summary>
    public interface InstagramService
    {
        Task<InstagramDto> getPostInformation(string postId);
    }

    /// <summary>
    /// This class allows us to get the Instagram post information
    /// and append a unique id to the post information in order to identify it.
    /// </summary>
    /// <returns>A unique post information id string</returns>

    public class instagramService
        {

        /// <summary>
        /// This function allows us a way to organize data of instagram posts
        /// that are shared throughout the app.
        /// </summary>
        /// <returns>A unique post information id string</returns>
        public async Task<InstagramDto> GetInstagramPost(string postId)
            {
                return await instagramService.getPostInformation(postId);
            }

        /// <summary>
        /// This function allows us a way to actually obtain the post information
        /// from Instagram.
        /// </summary>
        /// <returns>An emtpy task</returns>
        internal static Task<InstagramDto> getPostInformation(string postId)
            {
                throw new NotImplementedException();
            }
        }
