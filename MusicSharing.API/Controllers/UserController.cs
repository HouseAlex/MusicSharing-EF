using Microsoft.AspNetCore.Mvc;
using MusicSharing.Business.Services.Interfaces;
using MusicSharing.Contracts.Inputs;
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
    /// Checks to see if the spotify account exits in our system.
    /// </summary>
    /// <param name="spotifyId">The spotify user identifier.</param>
    /// <returns>A boolean indicating whethere the user exists.</returns>
    [HttpGet("{spotifyId}/exists")]
    public async Task<bool> CheckUserExists(string spotifyId)
    {
        return await userService.CheckUserExists(spotifyId);
    }

    /// <summary>
    /// Gets a user based on their spotify id.
    /// </summary>
    /// <param name="spotifyId">The spotify user identifier.</param>
    /// <returns>The user determined by their spotify id.</returns>
    public async Task<UserDto> GetUserFromSpotifyId(string spotifyId)
    {
        return await userService.GetUserFromSpotifyId(spotifyId);
    }

    /// <summary>
    /// Register a user if they are logining in for the first time
    /// </summary>
    /// <param name="payload">The new ueser information.</param>
    /// <returns>An empty task.</returns>
    [HttpPost("register")]
    public async Task RegisterUser([FromBody] NewUserPayload payload)
    {
        // Doesn't return anything right now, can if needed.
        await userService.AddUser(payload);
    }



    /*
    Test Endpoints Below
    */

    /// <summary>
    /// Placeholder function to show the process.
    /// </summary>
    /// <returns>An emtpy task</returns>
    [HttpGet("{id}")]
    public async Task<UserDto> GetUser(int id)
    {
        return await userService.GetUser(id);
    }

    /// <summary>
    /// Placeholder function to show the process.
    /// </summary>
    /// <returns>An emtpy task</returns>
    [HttpGet("TestSpotify")]
    public async Task Test()
    {
        await userService.Test();
    }

    /// <summary>
    /// Placeholder function to show the process.
    /// </summary>
    /// <returns>An emtpy task</returns>
    [HttpPost("info/save")]
    public async Task FrontEndTest()
    {
        await userService.Test();
    }
}

