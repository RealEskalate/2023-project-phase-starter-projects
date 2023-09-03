using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts;
using SocialSync.Application.Dtos.Authentication;
using SocialSync.Application.Features.Authentication.Requests;
using SocialSync.Domain.Entities;
using SocialSync.Application.Dto.Authentication.validator;
using Application.Contracts;

namespace SocialSync.Application.Features.Authentication.Handlers.Queries;

public class LoginUserRequestHanlder : IRequestHandler<LoginUserRequest,LoginResponseDto>{

    // readonly IAuthRepository _authRepository;
    private readonly IUnitOfWork _unitOfWork;
    readonly IMapper _mapper;
    readonly IJwtGenerator _jwtGenerator;

    public LoginUserRequestHanlder(IUnitOfWork unitOfWork, IMapper mapper, IJwtGenerator jwtGenerator)
    {
        // _authRepository = authRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _jwtGenerator = jwtGenerator;
    }
    public async Task<LoginResponseDto> Handle(LoginUserRequest request, CancellationToken cancellationToken){
        var validator = new LoginUserDtoValidator();
        var validationResult = await validator.ValidateAsync(request.LoginUserDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException();
        }
        // Check if user exists
        if (!await _unitOfWork.AuthRepository.UserExists(request.LoginUserDto.Email))
        {
            throw new Exception("User does not exist!");
        }
        
        // Login user
        var user = await _unitOfWork.AuthRepository.LoginUser(_mapper.Map<User>(request.LoginUserDto));
        
        // Generate token
        var token = await _jwtGenerator.CreateTokenAsync(user);
        await _unitOfWork.Save();
        
        return new LoginResponseDto
        {
            UserName = user.Username,
            Email = user.Email,
            Token = token
        };
    }
}