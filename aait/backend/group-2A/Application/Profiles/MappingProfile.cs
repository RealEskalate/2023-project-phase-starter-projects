using Application.DTO.CommentDTO;
using Application.DTO.Post;
using Application.DTO.UserDTO;
using Domain.Entities;

namespace Application.Profiles;

public class MappingProfile : AutoMapper.Profile
{

    public MappingProfile(){
        CreateMap<Post, PostDto>().ReverseMap();
        CreateMap<CreateUserDTO, User>();
        
        // Comment
        CreateMap<Comment, CommentDto>().ReverseMap();
        CreateMap<CreateCommentDto, Comment>().ReverseMap();
        CreateMap<UpdateCommentDto, Comment>().ReverseMap();
        
    }
    
}