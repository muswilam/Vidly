using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class NewCustomer_ViewModel
    {
        public IEnumerable<MembershipType> MembershipeTypes { get; set; }
        public Customer Customer { get; set; }
    }
}