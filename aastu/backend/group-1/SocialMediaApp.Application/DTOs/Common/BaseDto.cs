using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Common;

public class BaseDto
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
}
