using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRental)
        {
            // Get Customer from Context
            var customer = _context.Customers.Single(cust => cust.CustomerId == newRental.CustomerId);

            // Get Movies
            var movies = _context.Movies.Where(rentMov => newRental.MovieIds.Contains(rentMov.Id)).ToList();

            // iterate of movies and make obj of rental for every movie
            foreach(var movie in movies)
            {
                
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not Available");
                movie.NumberAvailable--;

                //  *** Check if customer rented movie before ***
                Rental movieIsRentend = _context.Rentals.FirstOrDefault(movRented => movRented.Customer.CustomerId == newRental.CustomerId && 
                    movRented.Movie.Id == movie.Id);
                if (movieIsRentend == null)
                {
                    Rental rental = new Rental()
                    {
                        Movie = movie,
                        Customer = customer,
                        DateRented = DateTime.Now
                    };
                    _context.Rentals.Add(rental);
                }
                else
                    return BadRequest("Error");
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
