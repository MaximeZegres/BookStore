using BookStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entities
{
    public class Order : AuditableEntity
    {
        public int CustomerId { get; set; }

        public DateTimeOffset? OrderDate { get; set; }

        public int OrderId { get; set; }

        public List<Book> Books { get; set; }
    }
}
