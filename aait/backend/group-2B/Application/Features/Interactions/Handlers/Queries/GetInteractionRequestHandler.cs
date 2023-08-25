using AutoMapper;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Domain.Entities;
using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.Features.Comments.Requests.Queries;

namespace SocialSync.Application.Features.Comments.Handlers.Commands;

public class GetInteractionRequestHandler
    : IRequestHandler<GetInteractionRequest, CommonResponse<Interaction>>
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public GetInteractionRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<Interaction>> Handle(GetInteractionRequest request, CancellationToken cancellationToken)
    {
        var foundInteraction = await _unitOfWork.InteractionRepository.GetAsync(request.Id);
        return CommonResponse<Interaction>.Success(foundInteraction);
    }
}