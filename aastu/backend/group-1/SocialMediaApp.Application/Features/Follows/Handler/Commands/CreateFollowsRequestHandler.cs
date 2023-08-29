using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using SocialMediaApp.Application.DTOs.Follows.Validators;
using SocialMediaApp.Application.Features.Follows.Request.Commands;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Application.Responses;
using SocialMediaApp.Domain;

namespace SocialMediaApp.Application.Features.Follows.Handler.Commands;

public class CreateFollowsRequestHandler: IRequestHandler<CreateFollowsRequest, BaseResponseClass>
{
    private readonly IFollowRepository _followRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateFollowsRequestHandler(IFollowRepository followRepository, IMapper mapper, IUserRepository userRepository)
    {
        _followRepository = followRepository;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<BaseResponseClass> Handle(CreateFollowsRequest request, CancellationToken cancellationToken)
    {
        var validator = new ValidateCreateFollow(_userRepository);

        var validationResult = await validator.ValidateAsync(request.createFollowDto);
        var response = new BaseResponseClass();
        var followExists = await _followRepository.IsAlreadyFollowing(request.createFollowDto.CurrentUser, request.createFollowDto.ToBeFollowed);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Creation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        else if (!followExists)
        {
            response.Success = false;
            response.Message = "Creation Failed";
            response.Errors = new List<string>()
            {
                "already following the current user"
            };
        }
        else
        {
            var follow = _mapper.Map<Follow>(request.createFollowDto);
            follow = await _followRepository.Add(follow);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = follow.Id;
        }


       
        
        return response;
    }

}
