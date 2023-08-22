using Application.DTO.PostDTO.DTO;
using AutoMapper;
using Domain.Entities;


namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {   
            CreateMap<PostResponseDTO, Post>().ReverseMap();
            CreateMap<PostCreateDTO, Post>().ReverseMap();
        }
    }
}
