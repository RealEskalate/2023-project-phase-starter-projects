using AutoMapper;
using SocialSync.Application.DTOs.PostDtos;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Profiles;

public class PostsMappingProfile: Profile{
    public PostsMappingProfile()
    {
        CreateMap<Post, PostDto>().ReverseMap();
        CreateMap<Post, CreatePostDto>().ReverseMap();
        CreateMap<Post, UpdatePostDto>().ReverseMap();

    }

}