﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.Common;

namespace Vidly.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(225)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [Display(Name = "Date Of Birth")]
        [MinYearMemberIs18]
        public Nullable<DateTime> BirthDate { get; set; }

        public MembershipType MembershipType { get; set; }
      
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        public Movie Movie { get; set; }
        public Nullable<int> MovieId { get; set; }
    }
}