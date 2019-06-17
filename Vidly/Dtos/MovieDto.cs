using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required, StringLength(225)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }

        public byte GenreId { get; set; }

        public GenreDto genre { get; set; }
    }
}