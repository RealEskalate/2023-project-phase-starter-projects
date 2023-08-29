using Application.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Common
{
    public class ReactionValidator : AbstractValidator<ReactionDTO>
    {
        public ReactionValidator()
        {
            RuleFor(X => X.ReactedId)
                .NotEmpty().WithMessage("The Reacted Content Id is Required")
                .NotNull().WithMessage("The Reacted Content Id is Required")
                .GreaterThan(0).WithMessage("Please Provide Valid Id");

            RuleFor(X => X.ReactionType)
                .NotEmpty().WithMessage("The Reaction Type is Required")
                .NotNull().WithMessage("The Reaction Type is Required")
                .MustAsync(async (reaction, cancellationToken) =>
                {
                    reaction.ToLower();
                    if (reaction == "like" || reaction == "dislike")
                    {
                        return true;
                    }
                    return false;
                })
                .WithMessage("The Reaction Type is only either Like or Dislike");

        }
    }
}
