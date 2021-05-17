using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Features.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAdress { get; set; }

        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"Customer's lastname: {FirstName}; Customer's firstname: {LastName}; Email Adress: {EmailAdress}; Phone Number:{PhoneNumber}";
        }
    }
}
