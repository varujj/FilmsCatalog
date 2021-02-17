using FilmsCatalog.Application.CommandExecutors;
using FilmsCatalog.Application.Dtos;
using FilmsCatalog.Application.Extensions;
using FilmsCatalog.Application.Querying;
using FilmsCatalog.Application.Validators;
using FilmsCatalog.Models;
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
        private const int PAGE_SIZE = 2;

        public FilmController(FilmCommandExecutor commandExecutor)
        {
            _commandExecutor = commandExecutor;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery]EntityQuery query)
        {
            query.PageSize = PAGE_SIZE;

            var queryResult = await _commandExecutor.GetFilmsByQuery(query);

            var viewModel = new FilmListViewModel
            {
                Films = queryResult.Data,
                Count = queryResult.Count,
                CurrentPage = query.CurrentPage,
                PageSize = query.PageSize,
                CurrentUserId = this.CurrentUserId()
            };

            return View(viewModel);
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

            return RedirectToAction("Index");
        }

        [HttpGet("{filmId}")]
        public async Task<IActionResult> Details(int filmId)
        {
            var filmDto = await _commandExecutor.GetFilm(filmId);

            if (filmDto == null)
                return RedirectToAction("Index");

            return View(filmDto);
        }
    }
}
