using AutoMapper;
using FluentValidation;
using MediatR;
using SocialMediaApp.Application.DTOs.Likes.Validators;
using SocialMediaApp.Application.Exceptions;
using SocialMediaApp.Application.Features.Likes.Request.Commands;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Application.Responses;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Likes.Handler.Commands;

public class CreateLikeCommandHandler : IRequestHandler<CreateLikeRequest, BaseResponseClass>
{
    private readonly ILikeRepository _likeRepository;
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateLikeCommandHandler(ILikeRepository likeRepository, IPostRepository postRepository , IMapper mapper, IUserRepository userRepository )
    {
        _likeRepository = likeRepository;
        _mapper = mapper;
        _postRepository = postRepository;
        _userRepository = userRepository;
        
    }

    public async Task<BaseResponseClass> Handle(CreateLikeRequest request, CancellationToken cancellationToken)
    {

        
        var validator = new CreateLikeDtoValidator(_postRepository,_userRepository);
        var validationResult = await validator.ValidateAsync(request.LikeDto, cancellationToken);

        var response = new BaseResponseClass();
        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Creation failed";
            response.Errors = validationResult.Errors.Select(err => err.ErrorMessage).ToList();
        }
        else if (! await _likeRepository.LikeExists(request.LikeDto.UserId, request.LikeDto.PostId))
        {
            response.Success = false;
            response.Message = "Creation failed";
            response.Errors = new List<string>() { "already liked by user"};
        }
        else
        {
            var like = _mapper.Map<Like>(request.LikeDto);
            like = await _likeRepository.Add(like);
            response.Success = true;
            response.Message = "Creation successful";
            response.Id = like.Id;
            
        }

        return response;
    }
}
