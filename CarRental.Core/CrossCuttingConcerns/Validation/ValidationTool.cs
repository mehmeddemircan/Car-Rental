using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {

        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                    var errorMessages = result.Errors.Select(error => error.ErrorMessage);
                    var errorMessage = string.Join(", ", errorMessages);
                    throw new ValidationException(errorMessage);
            }
        }
    }
}
