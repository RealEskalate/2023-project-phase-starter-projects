using Application.DTOs.Auth;
using Application.DTOs.Comments;
using Application.DTOS.Auth;
using Application.DTOs.Notifications;
using Application.DTOs.PostLikes;
using Application.DTOs.Posts;
using AutoMapper;
using Domain.Entities;
using Application.DTOs.Users;

namespace Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Post, CreatePostDto>().ReverseMap();
        CreateMap<Post, UpdatePostDto>().ReverseMap();
        CreateMap<Post, PostContentDto>().ReverseMap();
        CreateMap<Post, UpdatePostDto>().ReverseMap();
        
        CreateMap<Comment, CreateCommentDto>().ReverseMap();
        CreateMap<Comment, UpdateCommentDto>().ReverseMap();
        CreateMap<Comment, CommentContentDto>().ReverseMap();
        CreateMap<Comment, UpdateCommentDto>().ReverseMap();
        
        CreateMap<PostLike, ChangeLikeDto>().ReverseMap();
        CreateMap<PostLike, PostLikeContentDto>().ReverseMap();

        CreateMap<Notification, NotificationContentDto>().ReverseMap();
        CreateMap<Notification, GetNotificationDto>().ReverseMap();

        CreateMap<User, RegisterRequestDto>().ReverseMap();
        CreateMap<User, LoginRequestDto>().ReverseMap();
        CreateMap<User, LoginResponseDto>().ReverseMap();

        CreateMap<User, UpdateUserDto>().ReverseMap();
        CreateMap<User, UserDetail>().ReverseMap();
        CreateMap<User, UserListDto>().ReverseMap();

        CreateMap<Follow, FollowDto>().ReverseMap();

        CreateMap<Tag, TagDto>().ReverseMap();
        CreateMap<Tag, TagNameDto>().ReverseMap();
    }
}

