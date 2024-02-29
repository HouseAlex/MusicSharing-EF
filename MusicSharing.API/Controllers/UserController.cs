﻿using Microsoft.AspNetCore.Mvc;
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

}



// PostService.cs
/// <summary>
/// This class implements the post service and provides methods for obtaining post information.
/// </summary>
public class PostService : IPostService
{
    public async Task<PostDto> GetPost(string postId)
    {
        return await GetPostInformation(postId);
    }

    public async Task<PostDto> GetPostInformation(string postId)
    {
        throw new NotImplementedException();
    }
}

