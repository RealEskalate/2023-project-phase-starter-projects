using Application.DTO.Like;
using MediatR;

namespace Application.Features.Like.Request.Commands;

public class DeleteLikeCommand : IRequest<Unit>
{
    public int Id { get; set; }
    
}