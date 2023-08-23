using AutoMapper;
using SocialSync.Application.DTOs.Authentication;
using SocialSync.Domain.Entities;

namespace HRLeaveManagement.Application.Profiles;

public class AuthenticationMappingProfile : Profile
{
    public AuthenticationMappingProfile()
    {
        CreateMap<RegisterUserDto, User>();
        CreateMap<User, UserDto>();
    }
}
