using Application.DTO.Like;
using MediatR;

namespace Application.Features.Like.Request.Queries;

public class GetIsLikedQuery: IRequest<bool>
{
    public required LikedDto LikedDto{ get; set; }
    
}