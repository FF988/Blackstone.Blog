using Microsoft.EntityFrameworkCore;
using Blackstone.Models;
namespace Blackstone;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Blog> Blog { get; set; }
    public DbSet<BlogCategory> BlogCategory { get; set; }
}