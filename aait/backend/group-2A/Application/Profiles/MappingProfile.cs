using Application.DTO.CommentDTO;
using Application.DTO.CommentDTO;
using Application.DTO.FollowDTO;
using Application.DTO.Like;
using Application.DTO.Post;
using Application.DTO.UserDTO;
using Domain.Entities;

namespace Application.Profiles;

public class MappingProfile : AutoMapper.Profile
{

    public MappingProfile(){
        
        CreateMap<Post, PostDto>().ReverseMap();
        CreateMap<Post, UpdatePostDto>().ReverseMap();
        CreateMap<Post, CreateUserDTO>().ReverseMap();
        
        CreateMap<User, UserDto>();
        CreateMap<User, CreateUserDTO>();
        CreateMap<User, UpdatePostDto>();
        CreateMap<User, UserProfileDTO>();

        CreateMap<Follow, FollowDto>();
        CreateMap<Like, LikedDto>();
        CreateMap<CreateUserDTO, User>();
        
        // Comment
        CreateMap<Comment, CommentDto>().ReverseMap();
        CreateMap<CreateCommentDto, Comment>().ReverseMap();
        CreateMap<UpdateCommentDto, Comment>().ReverseMap();
        
    }
    
}