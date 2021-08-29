using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Features.Orders.Queries.GetOrderDetail
{
    public class OrderDetailVm
    {
        public int OrderId { get; set; }

        public Guid CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal OrderTotal { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public bool OrderPaid { get; set; }

        public bool OrderShipped { get; set; }

        public bool OrderContacted { get; set; }
    }
}
