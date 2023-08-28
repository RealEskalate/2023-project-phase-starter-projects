using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.CommentDTO.DTO;
using FluentValidation;

namespace Application.DTO.CommentDTO.Validations
{
    public class CommentUpdateValidation : AbstractValidator<CommentUpdateDTO> 
    {
     public CommentUpdateValidation()
     {
        Include(new CommonCommentValidation());
     }   
    }
}