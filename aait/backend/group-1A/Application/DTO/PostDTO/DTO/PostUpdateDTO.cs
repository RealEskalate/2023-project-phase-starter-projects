using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.PostDTO.DTO
{
    public class PostUpdateDTO : IBasePostDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
