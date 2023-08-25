using Application.DTOs.Common;
using FluentValidation;
using SocialSync.Application.Contracts.Persistence;

namespace SocialSync.Application.DTOs.Users.Validators;

public class FollowUnfollowDtoValidator : AbstractValidator<FollowUnFollowDto>
{
    private readonly IUnitOfWork _unitOfWork;


    public FollowUnfollowDtoValidator(IUnitOfWork unitOfWork)
    { 

        _unitOfWork = unitOfWork;


        RuleFor(f => f.FollwerId)
                .NotEmpty().WithMessage("{propertyNmae} is Required")
                .NotNull().WithMessage("{propertyName} is Required")
                .MustAsync(async (FollwerId, token) => {
                    var result = await _unitOfWork.UserRepository.GetAsync(FollwerId);
                    return result != null ;
                }


                );

        RuleFor(f => f.FollowedId )
                .NotEmpty().WithMessage("{propertyName }is not Null")
                .NotNull().WithMessage("{propertyName} is not Null")
                .MustAsync(async (FollwerId, token) =>
                {
                    var result = await _unitOfWork.UserRepository.GetAsync(FollwerId);
                    return result != null;
                });

    }
}