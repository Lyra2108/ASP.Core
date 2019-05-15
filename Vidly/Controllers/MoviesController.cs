using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Models;
using Vidly.ViewModels;

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
            var movies = _context.Movies
                .Include(dbMovie => dbMovie.Genre)
                .ToList();

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

        public IActionResult Edit(int id)
        {
            var movie = _context.Movies
                .Include(dbMovie => dbMovie.Genre)
                .SingleOrDefault(dbMovie => dbMovie.Id == id);

            if (movie == null)
                return NotFound();

            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        // GET: Movies/ByReleaseDate
        [Route(@"movies/released/{year:regex(^\d{{4}}$)}/{month:regex(^\d{{2}}$):range(1,12)}")]
        public ContentResult ByReleaseDate(int year, int month)
        {
            return Content($"{year}/{month}");
        }

        public IActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public IActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.Genre = movie.Genre;
            }

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
