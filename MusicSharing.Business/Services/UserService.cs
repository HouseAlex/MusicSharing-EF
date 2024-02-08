using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicSharing.Business.Services.Interfaces;
using MusicSharing.Contracts.Outputs;
using MusicSharing.Data.Contexts.Interfaces;

namespace MusicSharing.Business.Services;

/// <summary>
/// The user service.
/// </summary>
public class UserService : IUserService
{
    private readonly IMusicSharingContext context;
    private readonly IMapper mapper;


    /// <summary>
    /// The instance of the user service.
    /// </summary>
    /// <param name="context">The music sharing context.</param>
    public UserService(IMusicSharingContext context,
        IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    /// <summary>
    /// Gets the user for the identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>A bool for now.</returns>
    public async Task<UserDto> GetUser(int id)
    {
        var user = await context.GetUser(id);
        if (user == null)
        {
            throw new Exception();
        }

        return mapper.Map<UserDto>(user);
    }
}