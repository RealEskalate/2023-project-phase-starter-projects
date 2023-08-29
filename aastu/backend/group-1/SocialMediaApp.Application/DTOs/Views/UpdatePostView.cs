using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Views
{
    public class UpdatePostView : PostView
    {
        public Guid PostId { get; set; }
    }
}
