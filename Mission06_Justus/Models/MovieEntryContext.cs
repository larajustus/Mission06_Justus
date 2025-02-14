using Microsoft.EntityFrameworkCore;

namespace Mission06_Justus.Models;

public class MovieEntryContext : DbContext
{
    public MovieEntryContext(DbContextOptions<MovieEntryContext> options) : base (options)
    {
    }
    
    public DbSet<Movie> Movies { get; set; }
}