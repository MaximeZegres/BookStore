using BookStore.Application.Features.Books;
using BookStore.Application.Features.Books.Commands.CreateBook;
using BookStore.Application.Features.Books.Commands.DeleteBook;
using BookStore.Application.Features.Books.Commands.UpdateBook;
using BookStore.Application.Features.Books.GetBookDetail;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllBooks")]
        public async Task<ActionResult<List<BookListVm>>> GetAllBooks()
        {
            var dtos = await _mediator.Send(new GetBooksListQuery());
            return Ok(dtos);
        }


        [HttpGet("{id}", Name = "GetBookById")]
        public async Task<ActionResult<BookDetailVm>> GetBookById(Guid id)
        {
            var getBookDetailQuery = new GetBookDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getBookDetailQuery));
        }

        [HttpPost(Name = "AddBook")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateBookCommand createBookCommand)
        {
            var id = await _mediator.Send(createBookCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateBook")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateBookCommand updateBookCommand)
        {
            await _mediator.Send(updateBookCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteBook")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteBookCommand = new DeleteBookCommand() { BookId = id };
            await _mediator.Send(deleteBookCommand);
            return NoContent();
        }


    }
}
