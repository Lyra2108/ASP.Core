using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public IList<Customer> Customers { get; set; }
    }
}
