namespace PizzaCastle.OrderingService.Domain.Enums;

public enum OrderStatus
{
    Placed,
    Accepted,
    Preparing,
    Ready,
    Delivered,
    Cancelled,
    Rejected
}