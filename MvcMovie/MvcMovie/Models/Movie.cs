using System;
using System.ComponentModel.DataAnnotations;
// En orden de ser capaz de referenciar a DbContext y DbSet
using System.Data.Entity;


namespace MvcMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }

        //La validación especifica que el campo Título debe tener de 3 hasta 60 caracteres
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        //Se debe mostrar el campo Lanzamiento con formato para ingresar una fecha
        [Display(Name = "Release Date"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        //Las validaciones al campo Género especifican que es un campo obligatorio a completar
        //que no se pueden llenar con espacios en blanco
        //y que la máximo longitud de caracteres es de 30
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        //Se valida que en el campo Precio se agregue un número entre 1 a 100
        [Range(1, 100), DataType(DataType.Currency)]
        public decimal Price { get; set; }

        //El campo Rating no acepta espacios en blanco como un ingreso válido
        //y la longitud máxima es de 5
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(5)]
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
