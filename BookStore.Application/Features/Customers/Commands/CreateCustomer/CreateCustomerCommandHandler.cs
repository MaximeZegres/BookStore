using AutoMapper;
using BookStore.Application.Contracts.Persistence;
using BookStore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Application.Features.Customers.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Customer> _customerRepository;

        public CreateCustomerCommandHandler(IMapper mapper, IAsyncRepository<Customer> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            // need to add validation

            var customer = _mapper.Map<Customer>(request);
            customer = await _customerRepository.AddAsync(customer);
            return customer.CustomerId;
        }

    }
}
