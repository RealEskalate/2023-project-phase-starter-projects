using AutoMapper;
using SocialSync.Application.Features.Interactions.Requests.Commands;
using SocialSync.Application.Common.Responses;
using MediatR;
using SocialSync.Domain.Entities;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.InteractionDTOs.Validator;

namespace SocialSync.Application.Features.Interactions.Handlers.Commands;

public class LikeUnlikePostInteractionCommandHandler
    : IRequestHandler<LikeUnlikePostInteractionCommand, BaseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public LikeUnlikePostInteractionCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork
    )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(
        LikeUnlikePostInteractionCommand command,
        CancellationToken cancellationToken
    )
    {
        var response = new BaseCommandResponse();
        var validator = new LikeDtoValidator(_unitOfWork);

        var validationResult = await validator.ValidateAsync(command.LikeDto);

        if (!validationResult.IsValid)
        {
            response.Message = "Failed to create Comment";
            response.Success = false;
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        else
        {
            var createdInteraction = await _unitOfWork.InteractionRepository.LikeUnlikeInteractionAsync(
                _mapper.Map<Interaction>(command.LikeDto)
            );
            if (await _unitOfWork.SaveAsync() > 0)
            {
                response.Success = true;
                response.Message = "Comment liked/unliked Successfully";
                response.Id = createdInteraction.Id;
            }
            else
            {
                response.Message = "Failed to interact with like and unlike Comment";
                response.Success = false;
                response.Errors = new List<string>() { "Internal server error" };
            }
            
        }

        return response;
    }
}