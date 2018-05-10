using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using vidlyProject.Models;

namespace vidlyProject.Dtos
{
    public class MoviesDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int GenreId { get; set; }
        [Required]
        public string ReleaseDate { get; set; }
        [Required]
        public string DateAdded { get; set; }
        [Required]
        [Range(1, 25)]
        public int Stock { get; set; }
    }
}