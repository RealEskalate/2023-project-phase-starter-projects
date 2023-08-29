using AutoMapper;
using MediatR;
using SocialMediaApp.Application.DTOs.Users.Validations;
using SocialMediaApp.Application.Features.Users.Request.Commands;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;
using SocialMediaApp.Application.Exceptions;
using SocialMediaApp.Application.Responses;

namespace SocialMediaApp.Application.Features.Users.Handler.Commands;

public class CreateUsersRequestHandler: IRequestHandler<CreateUserRequest, BaseResponseClass>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUsersRequestHandler(IUserRepository userRepository,    IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

public async Task<BaseResponseClass> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var validator = new ValidateCreateUserDto(_userRepository);

        var validationResult = await validator.ValidateAsync(request.CreateUserDto);
        var response = new BaseResponseClass();

        if(validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Creation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }else{

        var user = _mapper.Map<User>(request.CreateUserDto);
        user = await _userRepository.Add(user);

        response.Success = true;
        response.Message = "Creation Successful";
        response.Id = user.Id;
        }
           
        return response;
        
    }
}
