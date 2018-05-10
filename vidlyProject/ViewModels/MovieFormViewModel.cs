using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidlyProject.Models;

namespace vidlyProject.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public List<MovieGenre> GenreList { get; set; }
        
    }
}