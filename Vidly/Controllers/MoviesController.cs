using Microsoft.AspNetCore.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ViewResult Random()
        {
            var movie = new Movie {Name = "Shrek!"};

            return View(movie);
        }

        // GET: Movies/ByReleaseDate
        public ContentResult ByReleaseDate(int year, int month)
        {
            return Content($"{year}/{month}");
        }
    }
}
