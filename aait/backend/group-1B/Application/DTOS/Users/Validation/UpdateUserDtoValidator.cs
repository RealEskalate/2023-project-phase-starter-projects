using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Users.Validation
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            RuleFor(u => u.Id)
                .NotEmpty().WithMessage("Id is required");
            RuleFor(u => u.FirstName)
                .NotEmpty().WithMessage("First name is required");

            RuleFor(u => u.LastName)
                .NotEmpty().WithMessage("Last name is required");

            RuleFor(u => u.Bio)
                .NotEmpty().WithMessage("Bio is required");
        }
    }
}
