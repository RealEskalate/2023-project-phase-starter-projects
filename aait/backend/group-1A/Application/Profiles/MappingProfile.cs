using Application.DTO.Common;
using Application.DTO.PostDTO.DTO;
using AutoMapper;
using Domain.Entities;
using SocialSync.Application.Dtos.Authentication;
using SocialSync.Domain.Entities;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {   
            CreateMap<PostResponseDTO, Post>().ReverseMap();
            CreateMap<PostCreateDTO, Post>().ReverseMap();
            CreateMap<ReactionDTO, PostReaction>().ReverseMap();
            CreateMap<ReactionResponseDTO, PostReaction>().ReverseMap();
            CreateMap<PostUpdateDTO, Post>().ReverseMap();
            
            CreateMap<RegisterUserDto, User>();
            CreateMap<LoginUserDto, User>();
        }
    }
}
