using PizzaCastle.OrderingService.Domain.Common;
using PizzaCastle.OrderingService.Domain.Enums;

namespace PizzaCastle.OrderingService.Domain.Entities;

public class Order : AuditableEntity
{
    public Guid Id { get; set; }
    public string BuyerId { get; set; }
    public decimal OrderTotal { get; set; }
    public DateTimeOffset OrderPlacedAt { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public ICollection<CartItem> CartItems { get; set; }
}