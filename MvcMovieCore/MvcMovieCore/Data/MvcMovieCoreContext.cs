using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcMovieCore.Models
{
    public class MvcMovieCoreContext : DbContext
    {
        public MvcMovieCoreContext (DbContextOptions<MvcMovieCoreContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMovieCore.Models.Movie> Movie { get; set; }
    }
}
