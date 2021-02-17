using FilmsCatalog.Application.Querying;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Application.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<EntityQueryResult<TEntity>> ApplyQueryAsync<TEntity>(this IQueryable<TEntity> source, EntityQuery query)
        {
            return new EntityQueryResult<TEntity>
            {
                Count = await source.CountAsync(),
                Data = await source.ApplyPaging(query).ToListAsync()
            };
        }

        private static IQueryable<TEntity> ApplyPaging<TEntity>(this IQueryable<TEntity> source, EntityQuery query)
        {
            var result = source;

            if (query.CurrentPage == 0)
                query.CurrentPage = 1;

            result = result.Skip((query.CurrentPage - 1) * query.PageSize)
                           .Take(query.PageSize);

            return result;
        }
    }
}
