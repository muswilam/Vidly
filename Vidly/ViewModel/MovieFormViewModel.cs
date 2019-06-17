﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModel
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required, StringLength(225)]
        public string Name { get; set; }

        [Required, Display(Name = "Release Date"),
         DisplayFormat(DataFormatString = "{0:d MMM yyyy}")]
        public DateTime? ReleaseDate { get; set; }

        [Required, Display(Name = "Number In Stock"),
         Range(1, 20)]
        public int? NumberInStock { get; set; }

        public int? NumberAvaliable { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
            NumberAvaliable = movie.NumberAvailable;
        }
    }
}