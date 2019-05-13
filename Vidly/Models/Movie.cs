using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CustomerId { get; set; }
        public virtual List<Customer> Customers { get; set; }
    }
}