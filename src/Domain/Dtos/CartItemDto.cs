using PizzaCastle.OrderingService.Domain.Entities;
using PizzaCastle.OrderingService.Domain.Enums;

namespace PizzaCastle.OrderingService.Domain.Dtos;

public class CartItemDto
{
    public Guid MenuItemId { get; set; }
    public string MenuItemName { get; set; }
    public string MenuItemImageUrl { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public ItemSize ItemSize { get; set; }
    public ItemCrust ItemCrust { get; set; }
}