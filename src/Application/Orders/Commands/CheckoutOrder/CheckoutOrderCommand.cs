using System.Runtime.Serialization;
using MediatR;
using PizzaCastle.OrderingService.Domain.Dtos;
using PizzaCastle.OrderingService.Domain.Enums;

namespace PizzaCastle.OrderingService.Application.Orders.Commands.CheckoutOrder;

[DataContract]
public class CheckoutOrderCommand : IRequest<CheckoutOrderDto>
{
    [DataMember]
    public string BuyerId { get; private set; }
    [DataMember]
    public IEnumerable<CartItemDto> CartItems { get; private set; }
    [DataMember]
    public decimal OrderTotal { get; private set; }
    [DataMember]
    public DateTime OrderPlacedAt { get; private set; }
    [DataMember]
    public OrderStatus OrderStatus { get; private set; }

    public CheckoutOrderCommand(string buyerId, IEnumerable<CartItemDto> cartItems, decimal orderTotal, DateTime orderPlacedAt)
    {
        BuyerId = buyerId;
        CartItems = cartItems;
        OrderTotal = orderTotal;
        OrderPlacedAt = orderPlacedAt;
        OrderStatus = OrderStatus.Placed;
    }
}