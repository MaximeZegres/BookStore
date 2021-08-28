using BookStore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Features.Orders.Commands
{
    public class CreateOrderCommand : IRequest<int>
    {
        public Guid CustomerId { get; set; }

        public DateTimeOffset? OrderDate { get; set; }

        public int OrderId { get; set; }

        public int OrderTotal { get; set; }

        public List<Book> Books { get; set; }

        public bool OrderPaid { get; set; }

        public bool OrderShipped { get; set; }

        public bool OrderContacted { get; set; }

    }
}
