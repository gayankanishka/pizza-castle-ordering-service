using Microsoft.EntityFrameworkCore;
using PizzaCastle.OrderingService.Domain.Entities;

namespace PizzaCastle.OrderingService.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

    public DbSet<MenuItem> MenuItems { get; set; } = default!;
    public DbSet<MenuCategory> MenuCategories { get; set; } = default!;

}