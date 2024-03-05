using Microsoft.AspNetCore.Mvc;
using MusicSharing.Business.Services.Interfaces;
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
    [HttpGet("{id}")]
    public async Task<UserDto> GetUser(int id)
    {
        return await userService.GetUser(id);
    }

    [HttpGet("TestSpotify")]
    public async Task Test()
    {
        await userService.Test();
    }

    [HttpPost("info/save")]
    public async Task FrontEndTest()
    {
        await userService.Test();
    }

    [HttpGet("post/titles")]
    public async Task<ActionResult<IEnumerable<string>>> GetPostTitles()
    {
        var postTitles = await userService.GetPostTitles();
        if (postTitles == null)
        {
            return NotFound();
        }
        return Ok(postTitles);
    }


}

