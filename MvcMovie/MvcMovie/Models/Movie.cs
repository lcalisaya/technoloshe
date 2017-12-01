using System;
using System.ComponentModel.DataAnnotations;
// En orden de ser capaz de referenciar a DbContext y DbSet
using System.Data.Entity;


namespace MvcMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        // Es lo mismo [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]

        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public string Rating { get; set; }
    }

    // La clase MovieDBContext representa el contexto de la BD movie en Entity Framework, el cual 
    // manejará la búsqueda, el almacenamiento y la actualización de las instancias de la clase Movie
    // en una base de datos.
    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}
