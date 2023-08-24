using Application.Contracts.Identity;
using Application.Contracts.Persistance;
using Application.Features.User.Request.Queries;
using Application.Model;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Handlers.Queries;

public class LoginHandler : IRequestHandler<Login, AuthResponse>{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAuthService _authService;


    public LoginHandler(IUnitOfWork unitOfWork, IMapper mapper, IAuthService authService)
    {
        _mapper = mapper; 
        _unitOfWork = unitOfWork;
        _authService = authService;
    }

    public async Task<AuthResponse> Handle(Login request, CancellationToken cancellationToken){
        var token = await _authService.Login(new AuthRequest(){
            Email = request.LogInDto.Email,
            Password = request.LogInDto.Password
        });
        var user = await _unitOfWork.userRepository.GetUserByEmail(request.LogInDto.Email);
        return new AuthResponse(){ Id = user.Id, Email = user.Email, Username = user.UserName, Token = token};
    }
}