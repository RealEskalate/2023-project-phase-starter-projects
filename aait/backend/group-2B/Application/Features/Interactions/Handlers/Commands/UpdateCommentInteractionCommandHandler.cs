using AutoMapper;
using MediatR;
using SocialSync.Domain.Entities;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.Features.Comments.Requests.Commands;
using SocialSync.Application.DTOs.InteractionDTOs.CommentDTOs.Validator;
using SocialSync.Application.Common.Exceptions;
using SocialSync.Application.Common.Responses;

namespace SocialSync.Application.Features.Interactions.Handlers.Commands;

public class UpdateCommentInteractionCommandHandler
    : IRequestHandler<UpdateCommentInteractionCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateCommentInteractionCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper
    )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(
        UpdateCommentInteractionCommand command,
        CancellationToken cancellationToken
    )
    {
        var response = new BaseCommandResponse();
        var validator = new UpdateCommentDtoValidator(_unitOfWork);

        var validationResult = await validator.ValidateAsync(command.UpdateCommentDto);

        if (!validationResult.IsValid)
        {
            response.Message = "Failed to update Comment";
            response.Success = false;
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        else
        {
            var foundComment =
                await _unitOfWork.InteractionRepository.GetAsync(command.UpdateCommentDto.Id);
            if (foundComment != null && foundComment.PostId == command.UpdateCommentDto.PostId &&
                command.UpdateCommentDto.UserId == foundComment.UserId)
            {
                await _unitOfWork.InteractionRepository.UpdateAsync(
                    foundComment);
                if (await _unitOfWork.SaveAsync() > 0)
                {
                    response.Success = true;
                    response.Message = "Comment updated Successfully";
                    response.Id = foundComment.Id;
                }
                else
                {
                    response.Message = "Failed to update Comment";
                    response.Success = false;
                    response.Errors = new List<string>() { "Internal server error" };
                }
            }
            else
            {
                response.Message = "Failed to update Comment";
                response.Success = false;
                response.Errors = new List<string>() { "Comment not found" };
            }
        }

        return response;
    }
}