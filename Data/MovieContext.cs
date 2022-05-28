using Microsoft.EntityFrameworkCore;
using Movie_App.Models;

namespace Movie_App.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
    }
}
