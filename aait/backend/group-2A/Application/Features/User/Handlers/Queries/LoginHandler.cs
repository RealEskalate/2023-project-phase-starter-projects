using Application.Contracts.Identity;
using Application.Contracts.Persistance;
using Application.Features.User.Request.Queries;
using Application.Model;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Handlers.Queries;

public class LoginHandler : IRequestHandler<Login, BaseCommandResponse<AuthResponse>>{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAuthService _authService;


    public LoginHandler(IUnitOfWork unitOfWork, IMapper mapper, IAuthService authService)
    {
        _mapper = mapper; 
        _unitOfWork = unitOfWork;
        _authService = authService;
    }

    public async Task<BaseCommandResponse<AuthResponse>> Handle(Login request, CancellationToken cancellationToken){
        try{
            var token = await _authService.Login(new AuthRequest(){
                Email = request.LogInDto.Email,
                Password = request.LogInDto.Password
            }, _unitOfWork.userRepository);
            var user = await _unitOfWork.userRepository.GetUserByEmail(request.LogInDto.Email);
            var res = new AuthResponse(){ Id = user.Id, Email = user.Email, Username = user.UserName, Token = token };
            return BaseCommandResponse<AuthResponse>.SuccessHandler(res);

        }
        catch(Exception ex){
            return BaseCommandResponse<AuthResponse>.FailureHandler(ex);
        }
    }
}