using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Persistence.Contracts;

public interface IGenericRepository<T> where T : class
{
    Task<IReadOnlyList<T>> GetAll();
    Task <bool> Exists(Guid id);
    Task<T> GetById(Guid id);
    Task<T> Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);



}
