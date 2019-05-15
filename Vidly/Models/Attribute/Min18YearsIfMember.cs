using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models.Attribute
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(validationContext.ObjectInstance is Customer customer))
                return new ValidationResult("Wrong type it can only validate customers");

            if ((customer.MembershipTypeId ?? 0) == MembershipType.Unknown
                || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthdate == null || customer.Birthdate > DateTime.Now.AddYears(-18))
                return new ValidationResult("The customer must be at least 18.");

            return ValidationResult.Success;
        }
    }
}
