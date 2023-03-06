using AluraFlixServer.Models;
using Microsoft.EntityFrameworkCore;

namespace AluraFlixServer.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options) {}

    public DbSet<Video> Videos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Seed();
    }
}
