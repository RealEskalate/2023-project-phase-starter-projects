using Application.DTO.Like;
using Application.Responses;
using MediatR;

namespace Application.Features.Like.Request.Queries;

public class GetIsLikedQuery: IRequest<BaseCommandResponse<bool>>
{
    public required LikedDto LikedDto{ get; set; }
    
}