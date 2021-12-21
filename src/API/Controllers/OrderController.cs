using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PizzaCastle.OrderingService.Application.Orders.Commands.CheckoutOrder;
using PizzaCastle.OrderingService.Domain.Dtos;

namespace PizzaCastle.OrderingService.API.Controllers
{
    [Route("api/v1/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        [Route("checkout")]
        [ProducesResponseType(typeof(CheckoutOrderDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CheckoutOrderAsync([FromBody] CheckoutOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Accepted(result);
        }
    }
}