using AutoMapper;
using MediatR;
using PizzaCastle.OrderingService.Application.Common.Interfaces;
using PizzaCastle.OrderingService.Domain.Dtos;
using PizzaCastle.OrderingService.Domain.Entities;

namespace PizzaCastle.OrderingService.Application.Orders.Commands.CheckoutOrder;

public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, CheckoutOrderDto>
{
    private readonly IOrderRepository _repository;
    private readonly IMapper _mapper;
    
    public CheckoutOrderCommandHandler(IMapper mapper, IOrderRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<CheckoutOrderDto> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
    {
        var total = request.CartItems?.Sum(x => x.UnitPrice * x.Quantity);
        
        if (total != request.OrderTotal)
        {
            return new CheckoutOrderDto()
            {
                Accepted = false
            };
        }
        
        var order = _mapper.Map<Order>(request);
        await _repository.AddAsync(order, cancellationToken);
        
        return new CheckoutOrderDto
        {
            OrderId = order.Id,
            Eta = DateTime.UtcNow.AddMinutes(30),
            Accepted = true
        };
    }
}