using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entites
{
    public class Notification : BaseEntity
    {
        public bool IsRead { get; set; } = false;
        public bool Post { get; set; } = false;

        public bool Comment { get; set; } = false;

        public bool Reaction { get; set; } = false;

        public bool Follow { get; set; } = false;

        public int NotificationContentId { get; set; }

        public int UserId { get; set; }

    }
}
        //[ForeignKey("User")]
