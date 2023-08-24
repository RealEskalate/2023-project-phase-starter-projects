using AutoMapper;
using SocialSync.Application.Features.Interactions.Requests.Commands;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using System.ComponentModel.DataAnnotations;
using SocialSync.Application.DTOs.InteractionDTOs.CommentDTOs.Validator;

namespace SocialSync.Application.Features.Interactions.Handlers.Commands;

public class DeleteCommentInteractionCommandHandler
    : IRequestHandler<DeleteCommentInteractionCommand, Unit>
{
   
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCommentInteractionCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork
    )
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(
        DeleteCommentInteractionCommand command,
        CancellationToken cancellationToken
    )
    {
        var validator = new DeleteCommentDtoValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(command.DeleteCommentInteractionDto);

        if (!validationResult.IsValid)
        {
            string errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
            throw new ValidationException(errors);
        }
        else
        {
            var foundComment = await _unitOfWork.InteractionRepository.GetAsync(command.DeleteCommentInteractionDto.Id);
            await _unitOfWork.InteractionRepository.DeleteAsync(foundComment);
            return Unit.Value;
        }
    }
}