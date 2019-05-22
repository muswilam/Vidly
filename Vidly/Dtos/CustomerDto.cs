using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Common;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(225)] 
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto membershipType { get; set; }

        //[MinYearMemberIs18]
        public Nullable<DateTime> BirthDate { get; set; }
    }
}