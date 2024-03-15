using AutoMapper;
using MusicSharing.Contracts.Outputs;
using MusicSharing.Data.Entities;

/// <summary>
/// The class for the automapper.
/// </summary>
namespace MusicSharing.Business.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            /// <summary>
            /// Creates mapping of the application with the database based on the user.
            /// </summary>
            CreateMap<User, UserDto>();
        }
    }
}
