using Application.DTOs.Comments;
using Application.DTOs.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Users
{
    public class UserDetail
    {
        public int Id { get; set; }

         public string FirstName { get; set; }

        public string LastName { get; set; }

        public string username { get; set; }

        public string Bio { get; set; }

        public List<PostContentDto> Posts { get; set; }    

        public List<CommentContentDto> Comments { get; set; }
    }
}
