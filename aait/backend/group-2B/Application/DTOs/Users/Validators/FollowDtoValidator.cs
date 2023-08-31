using Application.DTOs.Common;
using FluentValidation;
using SocialSync.Application.Contracts.Persistence;

namespace SocialSync.Application.DTOs.Users.Validators;

public class FollowDtoValidator : AbstractValidator<FollowUnFollowDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public FollowDtoValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        // RuleFor(f => f)
        //     .NotEmpty()
        //     .WithMessage("{PropertyName} is Required")
        //     .NotNull()
        //     .WithMessage("{PropertyName} is Required")
        //     .MustAsync(
        //         async (f, token) =>
        //         {
        //             var result = await _unitOfWork.UserRepository.GetAsync(f.FollwerId);
        //
        //             return result != null;
        //         }
        //     )
        //     .WithMessage("User not found.")
        //     .MustAsync(
        //         async (f, token) =>
        //         {
        //             var result = await _unitOfWork.UserRepository.GetAsync(f.FollwerId);
        //             var result2 = await _unitOfWork.UserRepository.GetAsync(f.FollowedId);
        //
        //             var user1 = result.Followings.FirstOrDefault(t => t.Id == f.FollowedId);
        //             return user1 == null;
        //         }
        //     )
        //     .WithMessage("You are already following this user.");
        //
        // RuleFor(f => f)
        //     .MustAsync(
        //         async (f, token) =>
        //         {
        //             var result = await _unitOfWork.UserRepository.GetAsync(f.FollwerId);
        //             return result != null;
        //         }
        //     )
        //     .WithMessage("User not found.");
    }
}
