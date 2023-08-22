using Application.DTOs.Comments;
using Application.DTOS.Auth;
using Application.DTOs.PostLikes;
using Application.DTOs.Posts;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Post, CreatePostDto>().ReverseMap();
        CreateMap<Post, PostContentDto>().ReverseMap();
        CreateMap<Comment, CreateCommentDto>().ReverseMap();
        CreateMap<Comment, CommentContentDto>().ReverseMap();
        CreateMap<PostLike, ChangeLikeDto>().ReverseMap();
        CreateMap<PostLike, PostLikeContentDto>().ReverseMap();

        CreateMap<User, RegisterRequestDto>().ReverseMap();
            CreateMap<User, LoginRequestDto>().ReverseMap();
            CreateMap<User, LoginResponseDto>().ReverseMap();
    }
}

