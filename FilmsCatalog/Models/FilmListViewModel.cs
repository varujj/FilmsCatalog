using FilmsCatalog.Application.Dtos;
using System.Collections.Generic;

namespace FilmsCatalog.Models
{
    public class FilmListViewModel
    {
        public List<FilmDto> Films { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
    }
}
