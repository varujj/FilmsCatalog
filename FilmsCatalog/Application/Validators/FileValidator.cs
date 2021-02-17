using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FilmsCatalog.Application.Validators
{
    public static class FileValidator
    {
        public static bool ValidateImage(IFormFile image)
        {
            return ValidateFormFile(image,
                                   new List<string> { ".png", ".jpg", ".jpeg" },
                                   new List<string>() { "image/png", "image/jpg", "image/jpeg" });
        }

        public static bool ValidateFormFile(IFormFile file, List<string> extensions, List<string> contentOctetStreams)
        {
            if (file == null)
                return false;

            var fileName = file.FileName.ToLower();

            if (extensions.Any(ex => Path.GetExtension(file.FileName) == ex) && contentOctetStreams.Contains(file.ContentType.ToLower()))
                return true;

            return false;
        }
    }
}
