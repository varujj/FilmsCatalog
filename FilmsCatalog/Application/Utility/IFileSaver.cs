using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FilmsCatalog.Application.Utility
{
    public interface IFileSaver
    {
        Task<string> Save(string name, IFormFile formFile);
    }
}
