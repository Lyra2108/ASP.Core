using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Vidly.Models;

namespace Vidly.Dto
{
    [AutoMap(typeof(Customer))]
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Required]
        public byte? MembershipTypeId { get; set; }
    }
}
