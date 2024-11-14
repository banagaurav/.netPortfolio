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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>().HasData(
            new Blog { BlogId = 1, Title = "Action", Image = "img1", textarea = "textarea" },
            new Blog { BlogId = 2, Title = "Scifie", Image = "img2", textarea = "textarea" },
            new Blog { BlogId = 3, Title = "History", Image = "img3", textarea = "textarea" }
        );
    }
}
