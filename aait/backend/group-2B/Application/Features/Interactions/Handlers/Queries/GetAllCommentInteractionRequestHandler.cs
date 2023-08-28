using SocialSync.Domain.Entities;
using MediatR;
using SocialSync.Application.Features.Comments.Requests.Queries;
using SocialSync.Application.Contracts.Persistence;
using AutoMapper;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.InteractionDTOs;

namespace SocialSync.Application.Features.Comments.Handlers.Commands;

public class GetAllCommentInteractionRequestHandler
    : IRequestHandler<GetAllCommentInteractionRequest, CommonResponse<List<InteractionDto>>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public GetAllCommentInteractionRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<List<InteractionDto>>> Handle(GetAllCommentInteractionRequest request,
        CancellationToken cancellationToken)
    {
        var foundInteraction = await _unitOfWork.InteractionRepository.GetAllCommentInteractionsAsync(request.PostId);
        return CommonResponse<List<InteractionDto>>.Success(_mapper.Map<List<InteractionDto>>(foundInteraction));
    }
}