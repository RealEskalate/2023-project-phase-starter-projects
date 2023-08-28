using Application.Model;
using Application.Responses;
using MediatR;

namespace Application.Features.User.Request.Queries;

public class Login: IRequest<BaseCommandResponse<AuthResponse?>>{
    public required AuthRequest LogInDto {
        get;
        set;
    }
}