using FilmsCatalog.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsCatalog.Application.Repositories
{
    public interface IDirectorRepository : IRepository<Director>
    {
        Task<List<Director>> GetDirectorsByTerm(string term, int take);
    }
}
