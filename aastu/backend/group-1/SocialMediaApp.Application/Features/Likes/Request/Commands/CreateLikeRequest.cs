using MediatR;
using SocialMediaApp.Application.DTOs.Likes;
using SocialMediaApp.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Likes.Request.Commands;

public class CreateLikeRequest: IRequest<BaseResponseClass> 
{
    public CreateLikeDto LikeDto { get; set; }
}
