using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FilmsCatalog.Application.Extensions
{
    public static class ObjectResultExtensions
    {
        public static IActionResult ToHttpResponse<T>(this T result)
        {
            return new ObjectResult(result) { StatusCode = (int)HttpStatusCode.OK };
        }
    }
}
