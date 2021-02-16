using FilmsCatalog.Domain.Abstract;
using System.Collections.Generic;

namespace FilmsCatalog.Domain.Entities
{
    public class Director : IAggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Film> Films { get; set; }
    }
}
