using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaCastle.OrderingService.Application.Orders.Commands.CheckoutOrder;
using PizzaCastle.OrderingService.Application.Orders.Queries.GetOrdersByBuyerId;
using PizzaCastle.OrderingService.Domain.Dtos;

namespace PizzaCastle.OrderingService.API.Controllers
{
    [Route("api/v1/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [Authorize]
        [HttpPost]
        [Route("checkout")]
        [ProducesResponseType(typeof(CheckoutOrderDto), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> CheckoutOrderAsync([FromBody] CheckoutOrderCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            if (result.Accepted)
            {
                return Created(nameof(CheckoutOrderAsync), result);
            }

            return BadRequest();
        }
        
        [Authorize]
        [HttpGet]
        [Route("{buyerId}/history")]
        [ProducesResponseType(typeof(IEnumerable<OrderDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> CheckoutOrderAsync([FromRoute] string buyerId,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetOrdersByBuyerIdQuery(buyerId), cancellationToken);
            return Ok(result);
        }
    }
}