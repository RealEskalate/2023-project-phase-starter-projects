using Application.Contracts.Auth;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.Auth.Validation
{
    public class RegisterRequestDtoValidator : AbstractValidator<RegisterRequestDto>
    {
        private readonly IAuthService _authService;

        public RegisterRequestDtoValidator(IAuthService authService)
        {
            _authService = authService;
            RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Firstname is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Lastname is required");
            RuleFor(x => x.Username)
             .NotEmpty().WithMessage("Username is required")
             .MinimumLength(6).WithMessage("Username shouldn't be less than 6 characters")
             .MustAsync(UserNameIsUnique).WithMessage("Username is already taken");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password can't be less than 6 characters");

            RuleFor(x => x.Bio)
                .NotEmpty().WithMessage("Bio is required")
                .MaximumLength(150).WithMessage("Bio can't be more than 150 characters");

        }

        private async Task<bool> UserNameIsUnique(string username, CancellationToken token)
        {
            return !await _authService.UserExists(username);
        }
    }
}
