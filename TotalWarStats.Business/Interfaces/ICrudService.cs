using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TotalWarStats.Business.Interfaces
{
    public interface ICRUDService<T> where T : class
    {
        Task<T> AddAsync(T entity);

        Task DeleteAsync(string entityId);

        Task<T> UpdateAsync(T entity);

        Task<IList<T>> GetAllAsync();

        Task<T> GetByIdAsync(string entityId);

        Task<IList<T>> GetByFilterAsync(Expression<Func<T, bool>> predicate);
    }
}
