using FluentValidation.Results;

namespace SocialSync.Application.Exceptions;

public class ValidationException : ApplicationException
{
    public List<string> Errors { get; set; } = new List<string>();

    public ValidationException(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            Errors.Add(error.ErrorMessage);
        }
    }
}
