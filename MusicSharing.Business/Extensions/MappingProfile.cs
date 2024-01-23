using AutoMapper;
using MusicSharing.Contracts.Outputs;
using MusicSharing.Data.Entities;

namespace MusicSharing.Business.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<User, UserDto>();
        }
    }
}
