using AutoMapper;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Domain.Entities;
using MediatR;
using SocialSync.Application.Features.Comments.Requests.Queries;

namespace SocialSync.Application.Features.Comments.Handlers.Commands;

public class GetInteractionRequestHandler
    : IRequestHandler<GetInteractionRequest, Interaction>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public GetInteractionRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Interaction> Handle(GetInteractionRequest request, CancellationToken cancellationToken)
    {
        var foundInteraction = await _unitOfWork.InteractionRepository.GetAsync(request.id);
        return foundInteraction;
    }
}