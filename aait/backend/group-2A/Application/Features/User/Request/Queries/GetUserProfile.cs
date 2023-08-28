using Application.DTO.UserDTO;
using Application.Responses;
using MediatR;

namespace Application.Features.User.Request.Queries;

public class GetUserProfile : IRequest<BaseCommandResponse<UserProfileDTO>>{
    public required int Id{ set; get; }
    
}