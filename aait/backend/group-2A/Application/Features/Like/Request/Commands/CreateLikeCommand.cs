using Application.DTO.Like;
using Application.Responses;
using MediatR;

public class CreateLikeCommand : IRequest<BaseCommandResponse>
{
 public required LikedDto like{ get; set; } 
}