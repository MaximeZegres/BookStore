using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Features.Orders.Queries.GetOrderDetail
{
    public class GetOrderDetailQuery : IRequest<OrderDetailVm>
    {
        public int OrderId { get; set; }
    }
}
