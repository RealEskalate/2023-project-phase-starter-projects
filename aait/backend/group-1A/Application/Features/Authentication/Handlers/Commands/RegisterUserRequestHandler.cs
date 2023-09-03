using System.ComponentModel.DataAnnotations;
using System.Net;
using Application.Contracts;
using Application.Dtos.Authentication;
using Application.Features.Authentication.Requests;
using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts;
using SocialSync.Application.Dto.Authentication.validator;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Authentication.Handlers.Commands;
public class RegisterUserRequestHandler : IRequestHandler<RegisterUserRequest, RegisterResponseDto>
{

    readonly IMapper _mapper;
    readonly IJwtGenerator _jwtGenerator;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserRequestHandler(IUnitOfWork unitOfWork,IMapper mapper, IJwtGenerator jwtGenerator)
    {
        _mapper = mapper;
        _jwtGenerator = jwtGenerator;
        _unitOfWork = unitOfWork;

    }
   public async Task<RegisterResponseDto> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
    {

        
        var validator = new RegisterUserDtoValidator();
        var validationResult = await validator.ValidateAsync(request.RegisterUserDto, cancellationToken);
        if (await _unitOfWork.AuthRepository.UserExists(request.RegisterUserDto.Email))
        {
            throw new Exception("User already exists");
        }

        var user = _mapper.Map<User>(request.RegisterUserDto);

        var registeredUser = await _unitOfWork.AuthRepository.RegisterUser(user);
        
        var token = await _jwtGenerator.CreateTokenAsync(registeredUser);
        await _unitOfWork.Save();
        
        return new RegisterResponseDto
        {   
            FirstName = registeredUser.FirstName,
            LastName = registeredUser.LastName,
            UserName = registeredUser.Username,
            Email = registeredUser.Email
        };

    }
}