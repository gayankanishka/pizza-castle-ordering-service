using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PizzaCastle.OrderingService.Application.Common.Interfaces;
using PizzaCastle.OrderingService.Domain.Dtos;

namespace PizzaCastle.OrderingService.Application.Orders.Queries.GetOrdersByBuyerId;

public class GetOrdersByBuyerIdQueryHandler : IRequestHandler<GetOrdersByBuyerIdQuery, IEnumerable<OrderDto>>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _repository;
    
    public GetOrdersByBuyerIdQueryHandler(IMapper mapper, IOrderRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    
    public async Task<IEnumerable<OrderDto>> Handle(GetOrdersByBuyerIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAll()
            .Where(x => x.BuyerId == request.BuyerId)
            .OrderByDescending(x => x.OrderPlacedAt)
            .Select(x => _mapper.Map<OrderDto>(x))
            .ToListAsync(cancellationToken);
    }
}