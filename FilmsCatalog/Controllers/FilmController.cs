using FilmsCatalog.Application.CommandExecutors;
using FilmsCatalog.Application.Dtos;
using FilmsCatalog.Application.Extensions;
using FilmsCatalog.Application.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FilmsCatalog.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class FilmController : Controller
    {
        private readonly FilmCommandExecutor _commandExecutor;

        public FilmController(FilmCommandExecutor commandExecutor)
        {
            _commandExecutor = commandExecutor;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View("Upsert", filmDto);
        }

        [HttpGet("{filmId?}")]
        public async Task<IActionResult> Upsert(int? filmId)
        {
            var filmDto = filmId != null 
                          ? await _commandExecutor.GetFilm(filmId.Value)
                          : new FilmDto();

            return View("Upsert", filmDto);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(FilmDto filmDto)
        {
            var isValid = new FilmUpsertValidator().Validate(filmDto, out string msg);

            if (!isValid)
            {
                ModelState.AddModelError("", msg);
                return View("Upsert");
            }

            await _commandExecutor.UpsertFilm(filmDto, this.CurrentUserId());

            return View("Upsert");
        }
    }
}
