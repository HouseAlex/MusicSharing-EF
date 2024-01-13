using Microsoft.AspNetCore.Mvc;
using MusicSharing.Buisness.Services.UserService;

/// <summary>
/// The controller for user information.
/// </summary>
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService userService; 

    /// <summary>
    /// The instance of the user controller.
    /// </summary>
    /// <param name="userService">The user service</param>
    public UserController(UserService userService)
    {
        this.userService = userService;
    }
}
