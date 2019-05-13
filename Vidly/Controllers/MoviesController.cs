using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ViewResult Index()
        {
            var movies = _context.Movies;

            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = _context.Movies
                .Include(dbMovie => dbMovie.Genre)
                .SingleOrDefault(dbMovie => dbMovie.Id == id);

            if (movie == null)
                return NotFound();

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
