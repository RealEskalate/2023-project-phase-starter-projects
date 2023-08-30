using Application.DTOs.Common;
using FluentValidation;
using SocialSync.Application.Contracts.Persistence;

namespace SocialSync.Application.DTOs.Users.Validators;

public class UnFollowDtoValidator : AbstractValidator<FollowUnFollowDto>
{
    private readonly IUnitOfWork _unitOfWork;


    public UnFollowDtoValidator(IUnitOfWork unitOfWork)
    {

        _unitOfWork = unitOfWork;


        RuleFor(f => f)
                    .MustAsync(async (f, token) =>
                    {
                        var result = await _unitOfWork.UserRepository.GetAsync(f.FollwerId);
                        var result2 = await _unitOfWork.UserRepository.GetAsync(f.FollowedId);

                        return result != null;
                    }).WithMessage("user not found")
                    .MustAsync(async (f, token) =>
                    {
                        var result = await _unitOfWork.UserRepository.GetAsync(f.FollwerId);
                        var result2 = await _unitOfWork.UserRepository.GetAsync(f.FollowedId);

                        var user1 = result.Followings.FirstOrDefault(t => t.Id == f.FollowedId);
                        return user1 != null;

                    });


        RuleFor(f => f.FollowedId)
                        .MustAsync(async (id, token) =>
                        {
                            var result = await _unitOfWork.UserRepository.GetAsync(id);
                            return result != null;
                        }).WithMessage("user not found");

    }
}