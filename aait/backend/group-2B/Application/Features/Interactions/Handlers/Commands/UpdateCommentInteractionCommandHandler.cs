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
    : IRequestHandler<UpdateCommentInteractionCommand, CommonResponse<int>>
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

    public async Task<CommonResponse<int>> Handle(
        UpdateCommentInteractionCommand command,
        CancellationToken cancellationToken
    )
    {
        var response = new BaseCommandResponse();
        var validator = new UpdateCommentDtoValidator(_unitOfWork);

        var validationResult = await validator.ValidateAsync(command.UpdateCommentDto);

        if (!validationResult.IsValid)
        {
            return CommonResponse<int>.Failure("validation error");
        }
        else
        {
            var foundComment =
                await _unitOfWork.InteractionRepository.GetAsync(command.UpdateCommentDto.Id);
            if (foundComment != null && foundComment.PostId == command.UpdateCommentDto.PostId &&
                command.UpdateCommentDto.UserId == foundComment.UserId)
            {
                foundComment.Body = command.UpdateCommentDto.Body;
                await _unitOfWork.InteractionRepository.UpdateAsync(
                    foundComment);
                if (await _unitOfWork.SaveAsync() > 0)
                {
                    return CommonResponse<int>.Success(foundComment.Id);
                }
                else
                {
                    return CommonResponse<int>.Failure("Internal server error");
                }
            }

            return CommonResponse<int>.Failure("Could not find the comment");
        }
    }
}