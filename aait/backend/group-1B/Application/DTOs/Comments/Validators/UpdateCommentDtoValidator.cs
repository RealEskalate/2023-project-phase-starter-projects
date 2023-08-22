using Application.Contracts.Persistence;
using FluentValidation;
using Microsoft.AspNetCore.SignalR;

namespace Application.DTOs.Comments.Validators;

public class UpdateCommentDtoValidator : AbstractValidator<UpdateCommentDto>
{
    public UpdateCommentDtoValidator(IPostRepository postRepository, ICommentRepository commentRepository)
    {
        Include(new BaseCommentDtoValidator(postRepository));

        RuleFor(dto => dto.Id)
            .MustAsync(async (id, token) =>
            {
                var exists = await commentRepository.Exists(id);
                return exists;
            }).WithMessage("Comment does not exist");

        RuleFor(dto => dto)
            .MustAsync(async (dto, token) =>
            {
                var comment = await commentRepository.Get(dto.Id);
                if (comment == null)
                    return false;
                
                return comment.UserId == dto.UserId;
            }).WithMessage("Unauthorized operation. You are not the owner of the comment");
    }
}