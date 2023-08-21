using AutoMapper;
using SocialSync.Application.DTOs.Authentication;
using SocialSync.Domain.Entities;

namespace HRLeaveManagement.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region BlogPost Mappings
        CreateMap<RegisterUserDto, User>();
        #endregion

        #region Comment Mappings
        #endregion
    }
}
