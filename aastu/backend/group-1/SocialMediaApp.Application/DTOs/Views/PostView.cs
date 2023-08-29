using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Views
{
    public class PostView
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public List<String>? HashTag { get; set; }
    }
}
