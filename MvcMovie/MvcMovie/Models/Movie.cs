using System;

// En orden de ser capaz de referenciar a DbContext y DbSet
using System.Data.Entity;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }

    // La clase MovieDBContext representa el contexto de la BD movie en Entity Framework, el cual 
    // manejará la búsqueda, el almacenamiento y la actualización de las instancias de la clase Movie
    // en una base de datos.
    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}
