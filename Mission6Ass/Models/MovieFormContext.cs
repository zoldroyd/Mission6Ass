using Microsoft.EntityFrameworkCore;

namespace Mission6Ass.Models;

public class MovieFormContext : DbContext
{
    public MovieFormContext(DbContextOptions<MovieFormContext> options) : base (options)
    {
        
    }
    
    public DbSet<MovieForm> MovieForms { get; set; }
}