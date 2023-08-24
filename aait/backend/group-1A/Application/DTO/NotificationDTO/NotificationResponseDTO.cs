using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO.NotificationDTO
{
    public class NotificationResponseDTO
    {
     public int Id { get; set; }   

    public string Content { get; set; }

    public int NotificationContentId { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsRead { get; set; }
    }
}