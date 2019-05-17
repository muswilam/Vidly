using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required , StringLength(225)]
        public string Name { get; set; }

        [Required , Display(Name= "Release Date") ,
         DisplayFormat(DataFormatString = "{0:d MMM yyyy}")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Required , Display(Name = "Number In Stock") ,
         Range(1 , 20)]
        public int NumberInStock { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
        public Genre Genre { get; set; }

        public List<Customer> Customers { get; set; }
    }
}