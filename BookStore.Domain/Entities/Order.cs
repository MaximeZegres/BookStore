using BookStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStore.Domain.Entities
{
    public class Order : AuditableEntity
    {
        public Guid CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public int OrderId { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal OrderTotal { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public bool OrderPaid { get; set; }

        public bool OrderShipped { get; set; }

        public bool OrderContacted { get; set; }

    }
}
