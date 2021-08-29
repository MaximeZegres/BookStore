using AutoMapper;
using BookStore.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Application.Features.Orders.Queries.GetOrderDetail
{
    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, OrderDetailVm>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public GetOrderDetailQueryHandler(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<OrderDetailVm> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId);

            var orderDetailDto = _mapper.Map<OrderDetailVm>(order);

            return orderDetailDto;
        }
    }
}
