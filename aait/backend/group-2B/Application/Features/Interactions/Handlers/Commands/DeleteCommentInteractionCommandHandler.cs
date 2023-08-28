using AutoMapper;
using SocialSync.Application.Features.Interactions.Requests.Commands;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using System.ComponentModel.DataAnnotations;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.InteractionDTOs.CommentDTOs.Validator;

namespace SocialSync.Application.Features.Interactions.Handlers.Commands;

public class DeleteCommentInteractionCommandHandler
    : IRequestHandler<DeleteCommentInteractionCommand, CommonResponse<int>>
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

    public async Task<CommonResponse<int>> Handle(
        DeleteCommentInteractionCommand command,
        CancellationToken cancellationToken
    )
    {
        var response = new BaseCommandResponse();
        var validator = new DeleteCommentDtoValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(command.DeleteCommentInteractionDto);

        if (!validationResult.IsValid)
        {
            return CommonResponse<int>.Failure("Validation error");
            
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
                    return CommonResponse<int>.Success(foundComment.Id);
                }
                else
                {
                    return CommonResponse<int>.Failure("Failed to delete comment");
                }
            }
            else
            {
                return CommonResponse<int>.Failure("Comment not found");
            }
        }

      
    }
}