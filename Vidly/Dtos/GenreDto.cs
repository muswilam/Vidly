using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class GenreDto
    {
        public byte Id { get; set; }

        [Required, StringLength(20)]
        public string GenreName { get; set; }
    }
}