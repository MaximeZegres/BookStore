using BookStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entities
{
    public class OrderItem : AuditableEntity
    {
        public Guid OrderItemId { get; set; }

        public int OrderId { get; set; }

        public int BookId { get; set; }

        public int Quantity { get; set; }
    }
}
