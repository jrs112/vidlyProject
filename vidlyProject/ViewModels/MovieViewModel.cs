using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidlyProject.Models;

namespace vidlyProject.ViewModels
{
    public class MovieViewModel
    {
        public List <Movie> MovieList { get; set; }
        public Movie Movie { get; set; }
    }
}