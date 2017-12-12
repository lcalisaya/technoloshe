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
        /// Acá definimos las relaciones N a N (many to many)
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany<Serie>(u => u.Favourites)
                .WithMany(f => f.Favourites)
                .Map(us =>
                {
                    us.MapLeftKey("UserMail");
                    us.MapRightKey("SerieId");
                    us.ToTable("Favourites");
                });
        }

        /// <summary>
        /// Colección para poder administrar Series en la base de datos
        /// </summary>
        public DbSet<Serie> Series { get; set; }
        /// <summary>
        /// Colección para poder administrar Generos en la base de datos
        /// </summary>
        public DbSet<Genre> Genres { get; set; }

        public DbSet<User> Users { get; set; }

    }
}