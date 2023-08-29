﻿using MediatR;
using SocialMediaApp.Application.DTOs.Follows;
using SocialMediaApp.Application.Responses;

namespace SocialMediaApp.Application.Features.Follows.Request.Commands;

public class CreateFollowsRequest:IRequest<BaseResponseClass>
{
    public CreateFollowDto createFollowDto {get; set;}
}
