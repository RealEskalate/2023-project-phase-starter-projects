
using SocialSync.Domain.Entities;
using MediatR;
using SocialSync.Application.Features.Comments.Requests.Queries;
using SocialSync.Application.Contracts.Persistence;
using AutoMapper;

namespace SocialSync.Application.Features.Comments.Handlers.Commands;
public class GetAllCommentInteractionRequestHandler
    : IRequestHandler<GetAllCommentInteractionRequest, List<Interaction>>
{
    private IInteractionRepository _interactionRepository;
    private IMapper _mapper;

    public GetAllCommentInteractionRequestHandler(IInteractionRepository interactionRepository, IMapper mapper)
        {
            _interactionRepository = interactionRepository;
            _mapper = mapper;
        }
    public async Task<List<Interaction>> Handle(GetAllCommentInteractionRequest request, CancellationToken cancellationToken)
    {
        var foundInteraction = await _interactionRepository.GetAllCommentInteractions(request.PostId);
        return foundInteraction;
    }
}

