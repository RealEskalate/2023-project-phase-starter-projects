using Application.Contracts.Persistance;
using Application.DTO.NotificationDTO;
using FluentValidation;

namespace Application.DTOs.Notifications.Validators;

public class UpdateNotificationDtoValidator : AbstractValidator<UpdateNotificationDto>
{
    public UpdateNotificationDtoValidator(INotificationRepository notificationRepository)
    {
        RuleFor(dto => dto.Id)
            .MustAsync(async (id, token) =>
            {
                var notif = await notificationRepository.GetNotification(id);
                return notif != null;
            }).WithMessage("Notification Does not exist");

        RuleFor(dto => dto)
            .MustAsync(async (dto, token) =>
            {
                var notif = await notificationRepository.GetNotification(dto.Id);
                return notif.UserId == dto.UserId;
            }).WithMessage("Unauthorized operation");
    }
}