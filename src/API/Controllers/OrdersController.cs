using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    }
}