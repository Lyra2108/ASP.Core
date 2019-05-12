using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IList<Customer> _customers = new List<Customer>
        {
            new Customer
            {
                Id = 0,
                Name = "abc"
            },
            new Customer
            {
                Id = 1,
                Name = "def"
            }
        };

        public ActionResult Index()
        {
            return View(_customers);
        }

        public ActionResult Details(int id)
        {
            return View(_customers[id]);
        }
    }
}
