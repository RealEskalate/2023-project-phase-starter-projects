using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> Errors { get; set; } = new List<string>();
        public ValidationException(ValidationResult validationResult) : base(" error has occured")
        {

            foreach (var error in validationResult.Errors)
            {
                Errors.Add(error.ErrorMessage);
            }



        }
    }
}
