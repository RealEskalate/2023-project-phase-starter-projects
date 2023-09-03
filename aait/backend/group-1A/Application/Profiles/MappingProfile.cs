using Application.DTO.CommentDTO.DTO;
using Application.DTO;
using Application.DTO.Common;
using Application.DTO.FollowDTo;
using Application.DTO.NotificationDTO;
using Application.DTO.PostDTO.DTO;
using Application.DTO.UserDTO.DTO;
using AutoMapper;
using Domain.Entites;
using Domain.Entities;
using SocialSync.Application.DTO;
using SocialSync.Domain.Entities;using SocialSync.Application.Dtos.Authentication;
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
            CreateMap<ReactionDTO, CommentReaction>().ReverseMap();
            CreateMap<ReactionResponseDTO, CommentReaction>().ReverseMap();
            CreateMap<PostUpdateDTO, Post>().ReverseMap();


            CreateMap<NotificationCreateDTO, Notification>().ReverseMap();
            CreateMap<NotificationResponseDTO, Notification>().ReverseMap();
            CreateMap<RegisterUserDto, User>();
            CreateMap<LoginUserDto, User>();
            

            
            CreateMap<CommentResponseDTO, Comment>().ReverseMap();
            CreateMap<CommentCreateDTO, Comment>().ReverseMap();
            CreateMap<CommentUpdateDTO, Comment>().ReverseMap();
            CreateMap<TagResponseDto, Tag>().ReverseMap();
            
        

            CreateMap<FollowDTO, Follow>().ReverseMap();
            CreateMap<UserResponseDTO, User>().ReverseMap();
            CreateMap<UserCreateDTO, User>().ReverseMap();
            CreateMap<UserUpdateDTO, User>().ReverseMap();
        }
    }
}
