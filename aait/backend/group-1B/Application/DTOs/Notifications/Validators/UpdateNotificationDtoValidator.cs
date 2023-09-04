using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.DTOs.Notifications.Validators;

public class UpdateNotificationDtoValidator : AbstractValidator<UpdateNotificationDto>
{
    public UpdateNotificationDtoValidator(INotificationRepository notificationRepository)
    {
        RuleFor(dto => dto.Id)
            .MustAsync(async (id, token) =>
            {
                var notif = await notificationRepository.Get(id);
                return notif != null;
            }).WithMessage("Notification Does not exist");

        RuleFor(dto => dto)
            .MustAsync(async (dto, token) =>
            {
                var notif = await notificationRepository.Get(dto.Id);
                return notif.UserId == dto.UserId;
            }).WithMessage("Unauthorized operation");
    }
}