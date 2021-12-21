using AutoMapper;
using PizzaCastle.OrderingService.Application.Orders.Commands.CheckoutOrder;
using PizzaCastle.OrderingService.Domain.Dtos;
using PizzaCastle.OrderingService.Domain.Entities;

namespace PizzaCastle.OrderingService.Application.Orders;

public class OrderMapping : Profile
{
    public OrderMapping()
    {
        CreateMap<CheckoutOrderCommand, Order>();
        CreateMap<Order, OrderDto>();
        CreateMap<CartItemDto, CartItem>()
            .ReverseMap();
    }
}