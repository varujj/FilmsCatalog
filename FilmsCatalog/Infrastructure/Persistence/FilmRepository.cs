using FilmsCatalog.Application.Repositories;
using FilmsCatalog.Domain.Entities;

namespace FilmsCatalog.Infrastructure.Persistence
{
    public class FilmRepository : Repository<Film>, IFilmRepository
    {
        public FilmRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
