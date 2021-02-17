using FilmsCatalog.Application.Dtos;
using FilmsCatalog.Application.Exceptions;
using FilmsCatalog.Application.Querying;
using FilmsCatalog.Application.Repositories;
using FilmsCatalog.Application.Utility;
using FilmsCatalog.Domain.Entities;
using FilmsCatalog.Domain.Exceptions;
using System.Threading.Tasks;

namespace FilmsCatalog.Application.CommandExecutors
{
    public class FilmCommandExecutor
    {
        private readonly IFilmRepository _repository;
        private readonly IFileSaver _fileSaver;

        public FilmCommandExecutor(IFilmRepository repository, IFileSaver fileSaver)
        {
            _repository = repository;
            _fileSaver = fileSaver;
        }

        public async Task<EntityQueryResult<FilmDto>> GetFilmsByQuery(EntityQuery query)
        {
            var films = await _repository.GetFilmsByQuery(query);

            return films.ConvertTo(f => FilmDto.FromFilm(f));
        }

        public async Task<FilmDto> GetFilm(int filmId)
        {
            var film = await _repository.GetFilm(filmId);

            if (film == null)
                throw new NotFoundException();

            return FilmDto.FromFilm(film);
        }

        public async Task UpsertFilm(FilmDto filmDto, string currentUserId)
        {
            var film = filmDto.Id > 0 
                       ? await _repository.GetAsync(filmDto.Id)
                       : Film.Create();

            if (!film.IsNew && film.AuthorId != currentUserId)
                throw new DomainException("Только автор может изменять фильм");

            film.Name = filmDto.Name;
            film.Description = filmDto.Description;
            film.AuthorId = currentUserId;
            film.Year = filmDto.Year;
            film.DirectorId = filmDto.DirectorId;

            if (filmDto.Poster != null)
            {
                // Ideally, thumbnail should be created
                film.PosterUrl = await _fileSaver.Save(film.Name, filmDto.Poster);
            }

            await _repository.UpsertAsync(film);
        }
    }
}
