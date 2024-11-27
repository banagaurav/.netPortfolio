using System;
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
        // Configurations for Band-Photo relationship (if necessary)
        modelBuilder.Entity<Photo>()
            .HasOne(p => p.Band)
            .WithMany(b => b.Photos)
            .HasForeignKey(p => p.BandId)
            .OnDelete(DeleteBehavior.SetNull); // Optional delete behavior

        // Configure optional one-to-many relationship
        modelBuilder.Entity<Photo>()
            .HasOne(p => p.Blog)
            .WithMany(b => b.Photos) // A blog can have multiple photos if needed
            .HasForeignKey(p => p.BlogId)
            .OnDelete(DeleteBehavior.Cascade); // Delete photos when the related blog is deleted

        // Seed Blog data
        modelBuilder.Entity<Blog>().HasData(
            new Blog
            {
                BlogId = 1,
                Title = "Introduction to .NET",
                Image = "https://example.com/images/dotnet.jpg",
                BlogDescription = "This blog post introduces the basics of .NET framework.",
                DisplayOrder = 1
            },
            new Blog
            {
                BlogId = 2,
                Title = "Understanding C#",
                Image = "https://example.com/images/csharp.jpg",
                BlogDescription = "A deep dive into the C# programming language and its features.",
                DisplayOrder = 2
            },
            new Blog
            {
                BlogId = 3,
                Title = "ASP.NET MVC for Beginners",
                Image = "https://example.com/images/aspnetmvc.jpg",
                BlogDescription = "This blog explains the fundamentals of ASP.NET MVC.",
                DisplayOrder = 3
            }
        );

        base.OnModelCreating(modelBuilder);
    }

}
