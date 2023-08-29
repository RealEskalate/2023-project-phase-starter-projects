using AutoMapper;
using SocialSync.Application.DTOs.InteractionDTOs;
using SocialSync.Application.DTOs.InteractionDTOs.CommentDTOs;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Profiles;

public class InteractionMappingProfile : Profile
{
    public InteractionMappingProfile()
    {
        CreateMap<Interaction, InteractionDto>().ReverseMap();
        CreateMap<Interaction, UpdateCommentInteractionDto>().ReverseMap();
    }
}