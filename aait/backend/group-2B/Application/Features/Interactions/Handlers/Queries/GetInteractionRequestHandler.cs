using AutoMapper;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Domain.Entities;
using MediatR;
using SocialSync.Application.Features.Comments.Requests.Queries;

namespace SocialSync.Application.Features.Comments.Handlers.Commands;

public class GetInteractionRequestHandler
    : IRequestHandler<GetInteractionRequest, Interaction>
{
    private IInteractionRepository _interactionRepository;
    private IMapper _mapper;

    public GetInteractionRequestHandler(IInteractionRepository interactionRepository, IMapper mapper)
    {
        _interactionRepository = interactionRepository;
        _mapper = mapper;
    }

    public async Task<Interaction> Handle(GetInteractionRequest request, CancellationToken cancellationToken)
    {
        var foundInteraction = await _interactionRepository.GetAsync(request.id);
        return foundInteraction;
    }
}