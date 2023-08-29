using FluentValidation;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Application.DTOs.Users.Validations;

namespace SocialMediaApp.Application.DTOs.Users.Validations
{
    public class ValidateUpdateUserDto:AbstractValidator<UpdateUserDto>
    {
        private readonly IUserRepository _userRepository;

        public ValidateUpdateUserDto(IUserRepository userRepository)
        {

        _userRepository = userRepository;
        Include(new IValidateUserDto());

        
        RuleFor(u => u.Id)
        .NotEmpty().WithMessage("{PropertyName} must required");
        // .MustAsync(async (id, token) =>
        // {
        //     var userIdExist = await _userRepository.Exists(id);
        //     return userIdExist;
        // })
        // .WithMessage("{PropertyName} does not exist.");
        }
       
        
    }
}