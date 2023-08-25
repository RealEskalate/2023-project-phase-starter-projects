using SocialSync.Domain.Entities;
using MediatR;
using SocialSync.Application.Features.Comments.Requests.Queries;
using SocialSync.Application.Contracts.Persistence;
using AutoMapper;
using SocialSync.Application.Common.Responses;

namespace SocialSync.Application.Features.Comments.Handlers.Commands;

public class GetAllCommentInteractionRequestHandler
    : IRequestHandler<GetAllCommentInteractionRequest, CommonResponse<List<Interaction>>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public GetAllCommentInteractionRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<List<Interaction>>> Handle(GetAllCommentInteractionRequest request,
        CancellationToken cancellationToken)
    {
        var foundInteraction = await _unitOfWork.InteractionRepository.GetAllCommentInteractionsAsync(request.PostId);
        return CommonResponse<List<Interaction>>.Success(foundInteraction);
    }
}