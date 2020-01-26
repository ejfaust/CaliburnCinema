﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Caliburn.Models;
using Caliburn.ViewModels;
using System.Data.Entity;

namespace Caliburn.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        // GET: Movie/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };


            return View(viewModel);
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleasedDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }//end class MoviesController
}