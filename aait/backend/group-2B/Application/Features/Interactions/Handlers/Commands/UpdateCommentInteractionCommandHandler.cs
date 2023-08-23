using AutoMapper;

using MediatR;
using SocialSync.Domain.Entities;
using SocialSync.Application.Contracts.Persistence;

using SocialSync.Application.Features.Comments.Requests.Commands;
using SocialSync.Application.DTOs.InteractionDTOs.CommentDTOs.Validator;
using SocialSync.Application.Exceptions;

namespace SocialSync.Application.Features.Interactions.Handlers.Commands;
public class UpdateCommentInteractionCommandHandler
    : IRequestHandler<UpdateCommentInteractionCommand, Unit>
{
    private readonly IInteractionRepository _interactionRepository;
    private readonly IMapper _mapper;

    public UpdateCommentInteractionCommandHandler(
        IInteractionRepository interactionRepository,
        IMapper mapper
    )
    {
        _interactionRepository = interactionRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(
        UpdateCommentInteractionCommand command,
        CancellationToken cancellationToken
    )
    {
        var validator = new UpdateCommentDtoValidator();

        var validationResult = await validator.ValidateAsync(command.UpdateCommentDto);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult);
        }
        else
        {
            await _interactionRepository.UpdateAsync(_mapper.Map<Interaction>(command));

            return Unit.Value;
        }
    }
}

