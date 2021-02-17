using FilmsCatalog.Application.Extensions;
using FilmsCatalog.Application.Querying;
using FilmsCatalog.Application.Repositories;
using FilmsCatalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Infrastructure.Persistence
{
    public class FilmRepository : Repository<Film>, IFilmRepository
    {
        public FilmRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<Film> GetFilm(int filmId)
        {
            return _context.Films.Include(f => f.Director).FirstOrDefaultAsync(f => f.Id == filmId);
        }

        public Task<EntityQueryResult<Film>> GetFilmsByQuery(EntityQuery query)
        {
            IQueryable<Film> films = _context.Films;

            return films.ApplyQueryAsync(query);
        }
    }
}
