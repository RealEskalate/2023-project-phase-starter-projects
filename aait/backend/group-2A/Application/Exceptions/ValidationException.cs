using FluentValidation.Results;

namespace Application.Exceptions;

public class ValidationException : ApplicationException
{
    public List<string> Errors { get; set; }
    
    public ValidationException(ValidationResult validationResult) 
    {
        foreach (var error in validationResult.Errors)
        {
            Console.WriteLine(error.ErrorMessage);
            Errors.Add(error.ErrorMessage);
        }

    }
}