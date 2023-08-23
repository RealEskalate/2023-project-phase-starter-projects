using AutoMapper;
using SocialSync.Application.Features.Interactions.Requests.Commands;
using SocialSync.Application.Responses;
using MediatR;
using SocialSync.Domain.Entities;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.InteractionDTOs.Validator;

namespace SocialSync.Application.Features.Interactions.Handlers.Commands;

public class CreateCommentInteractionCommandHandler
    : IRequestHandler<CreateCommentInteractionCommand, BaseCommandResponse>
{
    private readonly IInteractionRepository _interactionRepository;
    private readonly IMapper _mapper;

    private readonly IUnitOfWork _unitOfWork;

    public CreateCommentInteractionCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork
    )
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseCommandResponse> Handle(
        CreateCommentInteractionCommand command,
        CancellationToken cancellationToken
    )
    {
        var response = new BaseCommandResponse();
        var validator = new CommentDTOValidator(_unitOfWork.PostRepository, _unitOfWork.UserRepository);

        var validationResult = await validator.ValidateAsync(command.CreateCommentDto);

        if (!validationResult.IsValid)
        {
            response.Message = "Failed to create Comment";
            response.Success = false;
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        else
        {
            var createdInteraction = await _unitOfWork.InteractionRepository.AddAsync(
                _mapper.Map<Interaction>(command)
            );
            response.Success = true;
            response.Message = "Comment Created Successfully";
            response.Id = createdInteraction.Id;
        }

        return response;
    }
}