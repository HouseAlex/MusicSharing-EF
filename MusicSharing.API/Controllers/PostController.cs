using Microsoft.AspNetCore.Mvc;
using MusicSharing.Business.Services;
using MusicSharing.Business.Services.Interfaces;
using MusicSharing.Contracts.Outputs;

namespace MusicSharing.API.Controllers;

/// <summary>
/// The controller for post information.
/// </summary>
[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostService service;

    public PostController(IPostService service)
    {
        this.service = service;
    }

    /// <summary>
    /// Asynchronously gets the post feed for the user.
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    /// <returns>A list of posts</returns>
    [HttpGet("feed/user/{userId}")]
    public async Task<IEnumerable<PostDto>> GetPostFeed(int userId)
    {
        return await service.GetPostFeed(userId);
    }

    [HttpGet("titles")]
    public async Task<ActionResult<IEnumerable<string>>> GetPostTitles()
    {
        var postTitles = await service.GetPostTitles();
        if (postTitles == null)
        {
            return NotFound();
        }
        return Ok(postTitles);
    }
}
