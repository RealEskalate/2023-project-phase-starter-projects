using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.CommentDTO.DTO;
using FluentValidation;

namespace Application.DTO.CommentDTO.Validations
{
    public class CommonCommentValidation : AbstractValidator<IBaseCommentDTO>
    {
        public CommonCommentValidation()
        {
             RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required")
                .NotNull().WithMessage("Content is required")
                .MinimumLength(1).WithMessage("Content must be greater than 1 characters");
        }
    }
}