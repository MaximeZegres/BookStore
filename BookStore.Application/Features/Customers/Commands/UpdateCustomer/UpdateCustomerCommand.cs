using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Features.Customers.Commands
{
    public class UpdateCustomerCommand : IRequest
    {
        public Guid CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAdress { get; set; }

        public string PhoneNumber { get; set; }
    }
}
