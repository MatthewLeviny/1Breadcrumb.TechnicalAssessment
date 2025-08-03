using _1Breadcrumb.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace _1Breadcrumb.Infra.Persistance;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}