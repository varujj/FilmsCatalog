using FilmsCatalog.Application.CommandExecutors;
using FilmsCatalog.Application.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FilmsCatalog.Controllers
{
    public class DirectorController : Controller
    {
        private readonly DirectorCommandExecutor _commandExecutor;

        public DirectorController(DirectorCommandExecutor commandExecutor)
        {
            this._commandExecutor = commandExecutor;
        }

        [HttpGet]
        public async Task<IActionResult> GetDirectorsByTerm(string term)
        {
            var directors = await _commandExecutor.GetDirectorsByTerm(term);

            return directors.ToHttpResponse();
        }
    }
}
