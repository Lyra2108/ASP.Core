using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var customers = _context.Customers;
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(dbCustomer => dbCustomer.Id == id);
            if (customer == null)
                return NotFound();

            return View(customer);
        }
    }
}
