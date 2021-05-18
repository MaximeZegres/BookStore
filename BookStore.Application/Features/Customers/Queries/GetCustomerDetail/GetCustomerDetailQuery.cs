using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Features.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQuery : IRequest<CustomerDetailVw> 
    {
        public Guid CustomerId { get; set; }
    }
}
