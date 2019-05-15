using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Common
{
    public class MinYearMemberIs18 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if (customer.BirthDate == null)
                return new ValidationResult("Birthdate is Required");

            DateTime today = DateTime.Today;

            int todayDate = (today.Year * 100 + today.Month) * 100 + today.Day;
            int birthDate = (customer.BirthDate.Value.Year * 100 + customer.BirthDate.Value.Month) * 100 + customer.BirthDate.Value.Day;

            int age = (todayDate - birthDate) / 10000;

            return (age < 18) ? new ValidationResult("Customer Must be over 18 years old") : ValidationResult.Success;
        }
    }
}