using FilmsCatalog.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace FilmsCatalog.Application.Dtos
{
    public class FilmDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string DirectorName { get; set; }
        public int DirectorId { get; set; }

        public IFormFile Poster { get; set; }
        public string PosterUrl { get; set; }

        public static FilmDto FromFilm(Film film)
        {
            return new FilmDto
            {
                Id = film.Id,
                Name = film.Name,
                Description = film.Description,
                Year = film.Year,
                DirectorName = film.Director.Name,
                DirectorId = film.DirectorId,
                PosterUrl = film.PosterUrl
            };
        }
    }
}
