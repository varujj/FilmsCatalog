using Microsoft.AspNetCore.Http;

namespace FilmsCatalog.Application.Dtos
{
    public class FilmDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int DirectorId { get; set; }

        public IFormFile Poster { get; set; }
    }
}
