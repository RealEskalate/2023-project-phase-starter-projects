﻿using Application.DTO.PostDTO.DTO;
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
            CreateMap<RegisterUserDto, User>();
            CreateMap<LoginUserDto, User>();
        }
    }
}
