using FilmsCatalog.Application.Dtos;
using FilmsCatalog.Application.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Application.CommandExecutors
{
    public class DirectorCommandExecutor
    {
        private readonly IDirectorRepository _repository;

        public DirectorCommandExecutor(IDirectorRepository repository)
        {
            this._repository = repository;
        }

        public async Task<List<AutoCompleteItem>> GetDirectorsByTerm(string term)
        {
            var directors = await _repository.GetDirectorsByTerm(term, 5);

            return directors.Select(d => new AutoCompleteItem
            {
                Label = d.Name,
                Value = d.Id
            }).ToList();
        }
    }
}
