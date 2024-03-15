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

    /// <summary>
    /// The instance of the post controller.
    /// </summary>
    /// <param name="postService">The post service</param>
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

    /// <summary>
    /// Enables the ability to create post comments asynchronously.
    /// </summary>
    /// <param name="commentModel">The model in which we create comments.</param>
    [HttpPost("{postId: int}/comment")]
    public async Task CreateComment(CommentCreatePayload commentModel)
    {
        await postService.CreateComment(commentModel);
    }

    /// <summary>
    /// Enables the ability to generate posts asynchronously.
    /// </summary>
    /// <param name="postModel">The model in which we generate posts.</param>
    [HttpPost]
    public async Task CreatePost(PostCreatePayload postModel)
    {
        await postService.CreatePost(postModel);
    }

    /// <summary>
    /// It retrieves post titles asynchronously.
    /// </summary>
    /// <returns>A list with postTitles.</returns>
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
