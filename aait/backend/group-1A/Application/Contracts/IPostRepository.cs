using Application.DTO.PostDTO.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<Post> Get(int id, int userId);
    }
}
