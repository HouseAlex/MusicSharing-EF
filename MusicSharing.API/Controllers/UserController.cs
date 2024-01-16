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

    /// <summary>
    /// Creation of new placeholder function.
    /// </summary>
    /// <returns>An emtpy task</returns>
}
