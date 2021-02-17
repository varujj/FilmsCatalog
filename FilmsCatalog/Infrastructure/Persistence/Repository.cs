using FilmsCatalog.Application.Repositories;
using FilmsCatalog.Domain.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace FilmsCatalog.Infrastructure.Persistence
{
    public class Repository<T> : IRepository<T> where T : AggregateRoot
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<T>> GetAllAsync() => Set.ToListAsync();
        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression) => Set.Where(expression).ToListAsync();
        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression, int take) => Set.Where(expression).Take(take).ToListAsync();
        public Task<T> GetAsync(int id) => Set.FirstOrDefaultAsync(e => e.Id == id);
        public Task<T> GetAsync(Expression<Func<T, bool>> expression) => Set.FirstOrDefaultAsync(expression);

        public async Task UpsertAsync(T entity)
        {
            if (entity.IsNew)
            {
                await CreateAsync(entity);
                entity.IsNew = false;
            }
            else
                await UpdateAsync(entity);
        }

        public Task DeleteAsync(int id) => Set.Where(e => e.Id == id).DeleteAsync();

        private DbSet<T> Set => _context.Set<T>();

        private async Task CreateAsync(T item)
        {
            await Set.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        private async Task UpdateAsync(T item)
        {
            Set.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
