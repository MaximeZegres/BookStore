using AutoMapper;
using BookStore.Application.Contracts.Persistence;
using BookStore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Application.Features.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQueryHandler : IRequestHandler<GetCustomerDetailQuery, CustomerDetailVw>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Customer> _customerRepository;

        public GetCustomerDetailQueryHandler(IMapper mapper, IAsyncRepository<Customer> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDetailVw> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);

            var customerDetailDto = _mapper.Map<CustomerDetailVw>(customer);

            return customerDetailDto;
        }
    }
}
