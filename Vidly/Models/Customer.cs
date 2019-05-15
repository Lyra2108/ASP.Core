using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models.Attribute;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date of birth")]
        [Min18YearsIfMember]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Is subscribed to newsletter")]
        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Membership type")]
        public MembershipType MembershipType { get; set; }
        [Required]
        public byte? MembershipTypeId { get; set; }
    }
}
