using PizzaCastle.OrderingService.Domain.Entities;

namespace PizzaCastle.OrderingService.Application.Common.Interfaces;

public interface IOrderRepository
{
    Task<Order> AddAsync(Order order, CancellationToken cancellationToken);
    IQueryable<Order> GetAll();
}