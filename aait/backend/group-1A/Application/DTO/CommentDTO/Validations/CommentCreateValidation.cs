using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.CommentDTO.DTO;
using FluentValidation;

namespace Application.DTO.CommentDTO.Validations
{
    public class CommentCreateValidation : AbstractValidator<CommentCreateDTO>
    {
        public CommentCreateValidation()
        {
            Include(new CommonCommentValidation());
        }
    }
}