using System.Data.Entity;

namespace Technoloshe20173CSeriesMVC.Models
{
    /// <summary>
    /// Clase necesaria para conectarse a la base de datos
    /// usando entity framework.
    /// Se usa tanto para las migraciones como para la manipulación de los datos.
    /// </summary>
    public class SeriesContext : DbContext
    {
        /// <summary>
        /// El nombre que se especifica en el contructor padre, 
        /// es el que después se usa en el web.config para conectar
        /// a la base de datos
        /// </summary>
        public SeriesContext() : base("SeriesContext")
        {
 
        }
 
        /// <summary>
        /// Colección para poder administrar Series en la base de datos
        /// </summary>
        public DbSet<Serie> Series { get; set; }
        /// <summary>
        /// Colección para poder administrar Generos en la base de datos
        /// </summary>
        public DbSet<Genre> Genres { get; set; }
        
    }
}