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
    /// <param name="spotifyId">The user's spotify identifier.</param>
    /// <returns>A list of posts</returns>
    [HttpGet("feed/user/{spotifyId}")]
    public async Task<IEnumerable<PostDto>> GetPostFeed(string spotifyId)
    {
        return await service.GetPostFeed(spotifyId);
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
