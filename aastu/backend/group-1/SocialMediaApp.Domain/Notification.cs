using SocialMediaApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Domain;

public class Notification : BaseEntity
{
    public string Content { get; set; } = "";
    public Guid UserId { get; set; }
    public bool IsRead { get; set; }
}
