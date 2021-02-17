using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FilmsCatalog.Application.Repositories
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        Task<T> GetAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task UpsertAsync(T entity);
        Task DeleteAsync(int id);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression, int take);
    }
}
