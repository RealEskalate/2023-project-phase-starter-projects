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
    private readonly IInteractionRepository _interactionRepository;
    private readonly IMapper _mapper;

    public DeleteCommentInteractionCommandHandler(
        IInteractionRepository interactionRepository,
        IMapper mapper
    )
    {
        _interactionRepository = interactionRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(
        DeleteCommentInteractionCommand command,
        CancellationToken cancellationToken
    )
    {
        var validator = new DeleteCommentDtoValidator(_interactionRepository);
        var validationResult = await validator.ValidateAsync(command.deleteCommentInteractionDTO);

        if (!validationResult.IsValid)
        {
            var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
            throw new ValidationException(errors);
        }
        else
        {
            var foundComment = await _interactionRepository.GetAsync(command.deleteCommentInteractionDTO.Id);
            await _interactionRepository.DeleteAsync(foundComment);
            return Unit.Value;
        }
    }
}