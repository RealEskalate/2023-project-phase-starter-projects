using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.PostDTO.DTO
{
    public class PostCreateDTO : IBasePostDTO
    {

        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
