using Application.Model;
using MediatR;

namespace Application.Features.User.Request.Queries;

public class Login: IRequest<AuthResponse>{
    public required AuthRequest LogInDto {
        get;
        set;
    }
}