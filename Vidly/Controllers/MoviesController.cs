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
        [Route(@"movies/released/{year:regex(^\d{{4}}$)}/{month:regex(^\d{{2}}$):range(1,12)}")]
        public ContentResult ByReleaseDate(int year, int month)
        {
            return Content($"{year}/{month}");
        }
    }
}
