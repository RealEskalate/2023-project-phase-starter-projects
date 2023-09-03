
using FluentValidation;
using SocialSync.Application.Contracts.Persistence;

namespace Application.DTOs.Users.Validators;

public class UserDeleteDtoValidator : AbstractValidator<UserDeleteDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public UserDeleteDtoValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(f => f)
                .MustAsync(async (f, token) =>
                {
                    var result = await _unitOfWork.UserRepository.GetAsync(f.Id);
                    if (result != null && (f.Id == result.Id) && (f.Id == f.Owner))
                    {
                        return true;
                    }
                    return false;

                });
    }


}
