using AutoMapper;
using SocialSync.Application.Dtos.Authentication;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Profiles;

public class MappingProfile : Profile{
    public MappingProfile()
    {
        CreateMap<RegisterUserDto, User>();
        CreateMap<LoginUserDto, User>();
    }
}