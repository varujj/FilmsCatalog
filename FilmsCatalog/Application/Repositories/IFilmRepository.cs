using FilmsCatalog.Application.Querying;
using FilmsCatalog.Domain.Entities;
using System.Threading.Tasks;

namespace FilmsCatalog.Application.Repositories
{
    public interface IFilmRepository : IRepository<Film>
    {
        Task<Film> GetFilm(int filmId);
        Task<EntityQueryResult<Film>> GetFilmsByQuery(EntityQuery query);
    }
}
