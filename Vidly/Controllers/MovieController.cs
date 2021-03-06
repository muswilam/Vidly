﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModel;
using System.Data.Entity.Validation;
using AutoMapper;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.AdminManagment))
                return View("List");
            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.AdminManagment)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.AdminManagment)]
        public ActionResult Edit(int id)
        {
            Movie movie = _context.Movies.SingleOrDefault(mov => mov.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm",viewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
                movie.DateAdded = DateTime.Now;
                movie.NumberAvailable = movie.NumberInStock;
            }
            else
            {
                Movie movieInDb = _context.Movies.Single(mov => mov.Id == movie.Id);

                //movie.DateAdded = movieInDb.DateAdded;
                Mapper.Map(movie, movieInDb);

                //movieInDb.Name = movie.Name;
                //movieInDb.ReleaseDate = movie.ReleaseDate;
                //movieInDb.GenreId = movie.GenreId;
                //movieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index" , "Movie");
        }

        public ActionResult Details(int id)
        {
            Movie movie = _context.Movies.Include(g => g.Genre).Include(cust => cust.Customers).SingleOrDefault(mov => mov.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }
    }
}