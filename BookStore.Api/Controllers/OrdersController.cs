using BookStore.Application.Features.Orders.Queries.GetOrderDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetOrderById")]
        public async Task<ActionResult<OrderDetailVm>> GetOrderById(int id)
        {
            var getOrderDetailQuery = new GetOrderDetailQuery() { OrderId = id };
            return Ok(await _mediator.Send(getOrderDetailQuery));
        }
    }
}
