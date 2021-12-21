using MediatR;
using PizzaCastle.OrderingService.Domain.Dtos;

namespace PizzaCastle.OrderingService.Application.Orders.Queries.GetOrdersByBuyerId;

public class GetOrdersByBuyerIdQuery : IRequest<IEnumerable<OrderDto>>
{
    public string BuyerId { get; private set; }

    public GetOrdersByBuyerIdQuery(string buyerId)
    {
        BuyerId = buyerId;
    }
}