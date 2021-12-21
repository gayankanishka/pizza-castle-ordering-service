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

    public DbSet<Order> Orders { get; set; } = default!;
    public DbSet<CartItem> CartItems { get; set; } = default!;
}