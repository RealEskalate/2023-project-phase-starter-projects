using Application.Exceptions;
using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts;
using SocialSync.Application.Features.Requests;
using SocialSync.Domain.Entities;
using Application.Exceptions;

namespace SocialSync.Application.Features;

public class DeleteTagRequestHandler : IRequestHandler<DeleteTagRequest, Unit>
{
    IMapper _mapper;
    ITagRepository _tagRepository;
    public DeleteTagRequestHandler(IMapper mapper,ITagRepository tagRepository)
    {
        _mapper = mapper;
        _tagRepository = tagRepository;
    }
    public async Task<Unit> Handle(DeleteTagRequest request, CancellationToken cancellationToken)
    {
        var result = await _tagRepository.Exists(request.tag);

        if (!result){
            throw new NotFoundException("task not found");
        }

        return Unit.Value;
    }
}