using Application.DTO.Post;
using Domain.Entities;

namespace Application.Profiles;

public class MappingProfile : AutoMapper.Profile
{

    public MappingProfile(){
        CreateMap<Post, PostDto>().ReverseMap();
    }
    
}