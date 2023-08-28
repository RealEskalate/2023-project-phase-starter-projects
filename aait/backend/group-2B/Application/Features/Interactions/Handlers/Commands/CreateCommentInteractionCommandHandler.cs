using AutoMapper;
using SocialSync.Application.Features.Interactions.Requests.Commands;
using SocialSync.Application.Common.Responses;
using MediatR;
using SocialSync.Domain.Entities;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.InteractionDTOs.Validator;

namespace SocialSync.Application.Features.Interactions.Handlers.Commands;

public class CreateCommentInteractionCommandHandler
    : IRequestHandler<CreateCommentInteractionCommand, CommonResponse<int>>
{
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

    public async Task<CommonResponse<int>> Handle(
        CreateCommentInteractionCommand command,
        CancellationToken cancellationToken
    )
    {
        var response = new BaseCommandResponse();
        var validator = new CommentDtoValidator(_unitOfWork);
        
        var validationResult = await validator.ValidateAsync(command.CreateCommentDto);
        
        if (!validationResult.IsValid)
        {
            return CommonResponse<int>.Failure("Validation error");
        }
        else
        {
            var createdInteraction = await _unitOfWork.InteractionRepository.AddAsync(
                _mapper.Map<Interaction>(command.CreateCommentDto)
            );
            if (await _unitOfWork.SaveAsync() > 0)
            {
                return CommonResponse<int>.Success(createdInteraction.Id);
            }
            else
            {
                return CommonResponse<int>.Failure("Failed to create comment ");
            }
        }
    }
}