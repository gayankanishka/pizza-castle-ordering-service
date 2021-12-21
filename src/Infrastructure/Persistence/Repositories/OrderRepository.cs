using PizzaCastle.OrderingService.Application.Common.Interfaces;
using PizzaCastle.OrderingService.Domain.Entities;

namespace PizzaCastle.OrderingService.Infrastructure.Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Order> AddAsync(Order order, CancellationToken cancellationToken)
    {
        await _context.Orders.AddAsync(order, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return order;
    }

    public IQueryable<Order> GetAll()
    {
        return _context.Orders;
    }
}