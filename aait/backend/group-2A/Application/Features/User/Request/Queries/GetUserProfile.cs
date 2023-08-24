using Application.DTO.UserDTO;
using MediatR;

namespace Application.Features.User.Request.Queries;

public class GetUserProfile : IRequest<UserProfileDTO>{
    public required int Id{ set; get; }
    
}