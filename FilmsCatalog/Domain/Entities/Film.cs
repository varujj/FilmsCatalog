using FilmsCatalog.Domain.Abstract;

namespace FilmsCatalog.Domain.Entities
{
    public class Film : IAggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Путь к фотографии
        /// </summary>
        public string PosterUrl { get; set; }

        public int Year { get; set; }

        public Director Director { get; set; }
        public User Author { get; set; }
    }
}
