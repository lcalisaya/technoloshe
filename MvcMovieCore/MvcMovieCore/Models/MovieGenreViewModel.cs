using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovieCore.Models
{
    public class MovieGenreViewModel
    {
        // Una lista de películas
        public List<Movie> movies;
        
        // Una lista de selección que contendrá la lista de géneros. Esto permitirá al usuario seleccionar un género de la lista
        public SelectList genres;

        // Va a contener el género seleccionado
        public string movieGenre { get; set; }
    }
}
