using Application.DTOs.Common;

namespace Application.DTOs.Posts.Validators;

public class NotificationDto : BaseDto
{
    public string Message { get; set; } = "";
    public bool Seen { get; set; }
    

}