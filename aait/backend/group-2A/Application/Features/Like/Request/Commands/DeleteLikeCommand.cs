using Application.DTO.Like;
using Application.Responses;
using MediatR;

namespace Application.Features.Like.Request.Commands;

public class DeleteLikeCommand : IRequest<BaseCommandResponse<Unit>>
{
    public required LikedDto like{ get; set; } 
    
}