using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using vidlyProject.Models;
using vidlyProject.Dtos;
using AutoMapper;

namespace vidlyProject.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET api/<controller>
        public IEnumerable<MoviesDto> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie, MoviesDto>);
        }

        // GET api/<controller>/5
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Movie, MoviesDto>(movie));
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult CreateMovie(MoviesDto moviesDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MoviesDto, Movie>(moviesDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            moviesDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), moviesDto);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void UpdateMovie(int id, MoviesDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}