using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FilmsCatalog.Application.Extensions
{
    public static class ControllerExtensions
    {
        public static string CurrentUserId(this Controller controller)
        {
            return controller.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
