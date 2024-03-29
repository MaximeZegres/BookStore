﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<Guid>
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Editor { get; set; }

        public string ISBN { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"Book name: {Title}; Author: {Author}; Editor:{Editor}; ISBN: {ISBN}; Price:{Price}";
        }
    }
}
