using AutoMapper;
using BookStore.Application.Contracts.Persistence;
using BookStore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBookCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if(validationResult.Errors.Count > 0)
            {
                throw new Exceptions.ValidationException(validationResult);
            }

            var book = _mapper.Map<Book>(request);          

            book = await _bookRepository.AddAsync(book);

            return book.BookId;
        }
    }
}
