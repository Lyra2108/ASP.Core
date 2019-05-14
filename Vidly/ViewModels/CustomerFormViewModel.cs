using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IList<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}
