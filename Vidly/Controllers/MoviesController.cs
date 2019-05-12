using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ViewResult Random()
        {
            var movie = new Movie {Name = "Shrek!"};
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
                Movie = movie,
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
