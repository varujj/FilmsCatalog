using FilmsCatalog.Application.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FilmsCatalog.Infrastructure.Utility
{
    public class LocalFileSaver : IFileSaver
    {
        private readonly IWebHostEnvironment _environment;

        public LocalFileSaver(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public async Task<string> Save(string name, IFormFile formFile)
        {
            var uploads = Path.Combine(_environment.WebRootPath, "uploads");

            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            var fileName = name + "-" + Guid.NewGuid() + Path.GetExtension(formFile.FileName);
            var filePath = Path.Combine(uploads, fileName);
            var fileStream = new FileStream(filePath, FileMode.OpenOrCreate);

            await formFile.CopyToAsync(fileStream);

            fileStream.Close();

            return Path.Combine("uploads", fileName);
        }
    }
}
