using FluentValidation;
using SocialSync.Application.Contracts.Persistence;

namespace SocialSync.Application.DTOs.Notifications.Validators;

public class NotificationCreateDtoValidator : AbstractValidator<NotificationCreateDto>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public NotificationCreateDtoValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        Include(new INotificationDtoValidator());
        
        When(notification => notification.NotificationType == "Like", () => {
            
            RuleFor(notification => notification.PostId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .MustAsync(
                    async (dto, id, token) =>
                    {
                        var post = await _unitOfWork.PostRepository.GetAsync((int)id);
                       
                        return post != null & post.UserId == dto.RecepientId;
                    }
                ).WithMessage("Bad request");
        });

    }
}
