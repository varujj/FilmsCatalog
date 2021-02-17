using FilmsCatalog.Application.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Controllers
{
    [Authorize]
    public class FilmController : Controller
    {
        public IActionResult Create()
        {
            return View("Upsert");
        }

        [HttpPost]
        public IActionResult Create(FilmDto filmDto)
        {
            return View("Upsert");
        }

        public IActionResult Update(FilmDto filmDto)
        {
            return View("Upsert");
        }
    }
}
