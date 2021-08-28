using BookStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStore.Domain.Entities
{
    public class Book : AuditableEntity
    {
        public Guid BookId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Editor { get; set; }

        public string ISBN { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
    }
}
