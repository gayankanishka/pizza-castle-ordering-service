using PizzaCastle.OrderingService.Domain.Common;
using PizzaCastle.OrderingService.Domain.Enums;

namespace PizzaCastle.OrderingService.Domain.Entities;

public class CartItem : AuditableEntity
{
    public Guid MenuItemId { get; set; }
    public string MenuItemName { get; set; }
    public string MenuItemImageUrl { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public ItemSize ItemSize { get; set; }
    public ItemCrust ItemCrust { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
}