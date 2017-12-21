using System.Data.Entity;

namespace WeatherApp.Models
{
    public class WeatherContext : DbContext
    {
        public WeatherContext() : base("WeatherContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<WeatherComment> WeatherComments { get; set; }

        public DbSet<Voting> UserVotes { get; set; }

        public DbSet<UserCity> UserCities { get; set; }
    }
}