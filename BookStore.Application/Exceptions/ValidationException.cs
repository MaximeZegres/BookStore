using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> ValidatiorErrors { get; set; }

        public ValidationException(ValidationResult validationResult)
        {
            ValidatiorErrors = new List<string>();

            foreach(var validationError in validationResult.Errors)
            {
                ValidatiorErrors.Add(validationError.ErrorMessage);
            }
        }
    }
}
