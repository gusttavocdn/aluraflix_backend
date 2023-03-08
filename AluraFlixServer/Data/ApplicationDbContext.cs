using AluraFlixServer.Models;
using Microsoft.EntityFrameworkCore;

namespace AluraFlixServer.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Video> Videos { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Video>()
            .HasOne(video => video.Category)
            .WithMany(category => category.Videos)
            .HasForeignKey(video => video.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Seed();
    }
}
