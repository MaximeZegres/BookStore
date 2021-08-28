using AutoMapper;
using BookStore.Application.Contracts.Persistence;
using BookStore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Application.Features.Orders.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Order> _orderRepository;

        public CreateOrderCommandHandler(IMapper mapper, IAsyncRepository<Order> orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);
            order = await _orderRepository.AddAsync(order);
            return order.OrderId;
        }
    }
}
