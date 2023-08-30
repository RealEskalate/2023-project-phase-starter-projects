using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common;

namespace Application.DTO.NotificationDTO
{
    public class NotificationCreateDTO
    {
        public string Content { get; set; }

        public int NotificationContentId { get; set; }

        public NotificationEnum NotificationType { get; set; }

        public int UserId { get; set; }
    }
}