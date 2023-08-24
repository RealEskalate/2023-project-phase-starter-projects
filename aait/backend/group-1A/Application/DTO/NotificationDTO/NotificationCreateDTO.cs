using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO.NotificationDTO
{
    public class NotificationCreateDTO
    {
        public string Content { get; set; }

        public int NotificationContentId { get; set; }

        public string NotificationType { get; set; }
    }
}