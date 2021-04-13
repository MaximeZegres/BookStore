using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{Name} is required.");
        }
    }
}
