﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Features.Books
{
    public class GetBooksListQuery : IRequest<List<BookListVm>>
    {

    }
}
