using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Application.Contracts;
using Application.DTO.UserDTO.DTO;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using SocialSync.Domain.Entities;

namespace Application.DTO.UserDTO.validations
{
    public class UpdatePasswordValidation : AbstractValidator<UpdatePasswordDTO>
    {
        
        public UpdatePasswordValidation(UpdatePasswordDTO updatePasswordDTO,IUserRepository userRepository,int UserId)
        {
        
            RuleFor(x => x.OldPassword)
            .NotEmpty().WithMessage("Password is required")
            .NotNull().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long")
            .MustAsync(async (oldPassword, cancellation) => 
            {
                var newUser = await userRepository.Get(UserId);
                var passwordHash = new PasswordHasher<User>();
                var result = passwordHash.VerifyHashedPassword(newUser, newUser.Password, updatePasswordDTO.OldPassword);
                if (result == PasswordVerificationResult.Failed)
                {
                    return false;
                }

                    return true;
                }
                
            );

            RuleFor(x => x.NewPassword)
            .NotEmpty().WithMessage("Password is required")
            .NotNull().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long");

            RuleFor(x => x.ConfirmPassword)
            .NotEmpty().WithMessage("Password is required")
            .NotNull().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long")
            .MustAsync(async (confirmationPassword, cancellation) => 
            {
                return confirmationPassword == updatePasswordDTO.NewPassword;
            });
        
        }        
    }
}