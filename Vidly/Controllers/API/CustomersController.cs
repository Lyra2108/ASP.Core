using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerInDb = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();
            
            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

            await _context.SaveChangesAsync();

            return Ok(customerInDb);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);
            if (customer == null)
                return NotFound();

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
