using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using vidlyProject.Models;
using vidlyProject.ViewModels;

namespace vidlyProject.Controllers
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
 

        public ActionResult NewMovie()
        {

            var createGenreList = _context.MovieGenre.ToList();

            var viewModel = new MovieFormViewModel
            {
                GenreList = createGenreList
                
            };
            return View("ViewMovie", viewModel);
        }

        [HttpPost]
        public ActionResult SaveMovie(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    GenreList = _context.MovieGenre.ToList()
                };
                return View("ViewMovie", viewModel);
            }
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            } else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.Stock = movie.Stock;

            }
            _context.SaveChanges();
            return RedirectToAction("Random", "Movies");
        }


        // GET: Movies/Random
        public ActionResult Random()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();
            var viewModel = new MovieViewModel
            {
                MovieList = movies
            };
            return View(viewModel);
        }

        //Get Movies/ViewMovie
        public ActionResult ViewMovie(int id)
        {
            var movies = _context.Movies.ToList();
            var createGenreList = _context.MovieGenre.ToList();

            foreach (var movie in movies)
            {
                if (movie.Id == id)
                {
                    var viewModel = new MovieFormViewModel
                    {
                        Movie = movie,
                        GenreList = createGenreList
                    };
                    return View(viewModel);
                }
            }
            return View();
        }
    }
}