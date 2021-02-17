using FilmsCatalog.Application.Dtos;
using FilmsCatalog.Application.Repositories;
using FilmsCatalog.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Infrastructure.Persistence
{
    public class DirectorRepository : Repository<Director>, IDirectorRepository
    {
        public DirectorRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<List<Director>> GetDirectorsByTerm(string term, int take)
        {
            return GetAllAsync(d => d.Name.Contains(term), take);
        }
    }
}
