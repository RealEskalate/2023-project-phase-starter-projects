using SocialMediaApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Domain;

public class Like: BaseEntity 
{
    // it initiate the id in the base entitiy. the remaining part will be integrated in the context
    public Guid UserId { get; set; }
    public Guid PostId { get; set; }
        
}
