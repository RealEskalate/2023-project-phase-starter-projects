using AutoMapper;
using SocialSync.Application.Features.Interactions.Requests.Commands;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using System.ComponentModel.DataAnnotations;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.InteractionDTOs.CommentDTOs.Validator;

namespace SocialSync.Application.Features.Interactions.Handlers.Commands;

public class DeleteCommentInteractionCommandHandler
    : IRequestHandler<DeleteCommentInteractionCommand, BaseCommandResponse>
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

    public async Task<BaseCommandResponse> Handle(
        DeleteCommentInteractionCommand command,
        CancellationToken cancellationToken
    )
    {
        var response = new BaseCommandResponse();
        var validator = new DeleteCommentDtoValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(command.DeleteCommentInteractionDto);

        if (!validationResult.IsValid)
        {
            response.Message = "Failed to Delete Comment";
            response.Success = false;
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        else
        {
            var foundComment =
                await _unitOfWork.InteractionRepository.GetAsync(command.DeleteCommentInteractionDto
                    .Id);
            if (foundComment != null &&
                foundComment.PostId == command.DeleteCommentInteractionDto.PostId &&
                command.DeleteCommentInteractionDto.UserId == foundComment.UserId)
            {
                await _unitOfWork.InteractionRepository.DeleteAsync(foundComment);
                if (await _unitOfWork.SaveAsync() > 0)
                {
                    response.Success = true;
                    response.Message = "Comment Deleted Successfully";
                    response.Id = foundComment.Id;
                }
                else
                {
                    response.Message = "Failed to Delete Comment";
                    response.Success = false;
                    response.Errors = new List<string>() { "Internal server error" };
                }
            }
            else
            {
                response.Message = "Failed to Delete Comment";
                response.Success = false;
                response.Errors = new List<string>() { "Comment not found" };
            }
        }

        return response;
    }
}