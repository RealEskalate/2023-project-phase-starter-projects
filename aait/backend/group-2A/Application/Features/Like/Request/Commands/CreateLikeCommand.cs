using Application.DTO.Like;
using MediatR;

public class CreateLikeCommand : IRequest<Unit>
{
 public required LikedDto Like{ get; set; } 
}