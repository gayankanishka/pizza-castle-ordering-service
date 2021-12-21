using PizzaCastle.OrderingService.Domain.Entities;
using PizzaCastle.OrderingService.Domain.Enums;

namespace PizzaCastle.OrderingService.Domain.Dtos;

public class OrderDto
{
    public Guid Id { get; set; }
    public string BuyerId { get; set; }
    public IEnumerable<CartItem> CartItems { get; set; }
    public decimal OrderTotal { get; set; }
    public DateTimeOffset OrderPlacedAt { get; set; }
    public OrderStatus OrderStatus { get; set; }
}