using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using AutoMapper;


namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //Get List /api/movies
        public IHttpActionResult GetMovies()
        {
            var movies = _context.Movies.ToList().Select(Mapper.Map<Movie,MovieDto>);
            return Ok(movies);
        }

        //Get Movie /api/movies/1
        public IHttpActionResult GetMOvie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(mov => mov.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        //Post Movie /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto,Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //Update Movie /api/movies/i
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id , MovieDto movieDto)
        {
            var movieInDb = _context.Movies.SingleOrDefault(mov => mov.Id == id);

            if (movieInDb == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest("Something went wrong");

            Mapper.Map(movieDto,movieInDb);
            _context.SaveChanges();
            return Ok(movieDto);
        }

        //Delete Movie /api/movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(mov => mov.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
