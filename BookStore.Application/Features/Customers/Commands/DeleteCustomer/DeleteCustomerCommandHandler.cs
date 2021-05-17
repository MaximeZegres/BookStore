using AutoMapper;
using BookStore.Application.Contracts.Persistence;
using BookStore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Customer> _customerRepository;

        public DeleteCustomerCommandHandler(IMapper mapper, IAsyncRepository<Customer> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerToDelete = await _customerRepository.GetByIdAsync(request.CustomerId);

            await _customerRepository.DeleteAsync(customerToDelete);

            return Unit.Value;
        }
    }
}
