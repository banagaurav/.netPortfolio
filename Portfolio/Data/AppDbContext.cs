
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<Academic> Academics { get; set; }
    public DbSet<Band> Bands { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<User> Users { get; set; }
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Blog>().HasData(
    //         new Blog { BlogId = 1, Title = "Action", Image = "img1", BlogDescription = "textarea", DisplayOrder = 1 },
    //         new Blog { BlogId = 2, Title = "Scifie", Image = "img2", BlogDescription = "textarea", DisplayOrder = 2 },
    //         new Blog { BlogId = 3, Title = "History", Image = "img3", BlogDescription = "textarea", DisplayOrder = 3 }
    //     );
    // }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurations for Band-Photo relationship (if necessary)
        modelBuilder.Entity<Photo>()
            .HasOne(p => p.Band)
            .WithMany()
            .HasForeignKey(p => p.BandId)
            .OnDelete(DeleteBehavior.SetNull); // Optional delete behavior

        // Configure optional one-to-many relationship
        modelBuilder.Entity<Photo>()
            .HasOne(p => p.Blog)
            .WithMany() // A blog can have multiple photos if needed
            .HasForeignKey(p => p.BlogId)
            .OnDelete(DeleteBehavior.Cascade); // Delete photos when the related blog is deleted

        modelBuilder.Entity<User>().HasData(
            new User
            {
                UserId = 1,
                Username = "admin",
                Password = "admin", // Plain text for demonstration only
                Role = "Admin",
            }
        );
    }

}
