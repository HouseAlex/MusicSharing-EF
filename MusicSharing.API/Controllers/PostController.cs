using Microsoft.AspNetCore.Mvc;
using MusicSharing.Business.Models;
using MusicSharing.Business.Services;
using MusicSharing.Business.Services.Interfaces;

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

    [HttpPost("post")]
    public async Task<ActionResult> CreatePost(PostCreateModel postModel)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await postService.CreatePost(postModel);

        if(result)
        {
            return StatusCode(201);
        }
        else
        {
            return StatusCode(500);
        }
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
