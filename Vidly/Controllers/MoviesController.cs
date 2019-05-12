using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly List<Movie> _movies = new List<Movie>
        {
            new Movie
            {
                Id = 0,
                Name = "1"
            },
            new Movie
            {
                Id = 1,
                Name = "2"
            }
        };

        // GET: Movies/Random
        public ViewResult Index()
        {
            return View(_movies);
        }

        public ViewResult Details(int id)
        {
            var customers = new List<Customer>
            {
                new Customer {Name = "1"},
                new Customer {Name = "2"},
                new Customer {Name = "2"},
                new Customer {Name = "2"},
                new Customer {Name = "2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = _movies[id],
                Customers = customers
            };
            return View(viewModel);
        }

        // GET: Movies/ByReleaseDate
        [Route(@"movies/released/{year:regex(^\d{{4}}$)}/{month:regex(^\d{{2}}$):range(1,12)}")]
        public ContentResult ByReleaseDate(int year, int month)
        {
            return Content($"{year}/{month}");
        }
    }
}
