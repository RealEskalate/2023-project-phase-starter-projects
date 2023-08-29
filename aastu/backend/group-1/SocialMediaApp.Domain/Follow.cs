using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaApp.Domain.Common;

namespace SocialMediaApp.Domain;

public class Follow : BaseEntity
{
 
    public Guid CurrentUser { get; set; }
    public Guid ToBeFollowed { get; set; }
}

