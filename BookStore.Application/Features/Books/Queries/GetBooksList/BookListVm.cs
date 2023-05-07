﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Features.Books
{
    public class BookListVm
    {
        public Guid BookId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Editor { get; set; }

        public string ISBN { get; set; }

        public decimal Price { get; set; }
    }
}
