using Microsoft.AspNetCore.Mvc;
using MusicSharing.Business.Models;
using MusicSharing.Business.Services;
using MusicSharing.Business.Services.Interfaces;
using MusicSharing.Contracts.Inputs;
using MusicSharing.Contracts.Outputs;

namespace MusicSharing.API.Controllers;

/// <summary>
/// The controller for post information.
/// </summary>
[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostService postService;

    public PostController(IPostService postService)
    {
        this.postService = postService;
    }

    /// <summary>
    /// Asynchronously gets the post feed for the user.
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    /// <returns>A list of posts</returns>
    [HttpGet("feed/user/{userId}")]
    public async Task<IEnumerable<PostDto>> GetPostFeed(int userId)
    {
        return await postService.GetPostFeed(userId);
    }

    [HttpPost]
    public async Task CreatePost(PostCreatePayload postModel)
    {
        await postService.CreatePost(postModel);
    }
    
    [HttpGet("titles")]
    public async Task<ActionResult<IEnumerable<string>>> GetPostTitles()
    {
        var postTitles = await postService.GetPostTitles();
        if (postTitles == null)
        {
            return NotFound();
        }
        return Ok(postTitles);
    }

}
