using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts;
using SocialSync.Application.DTO;
using SocialSync.Application.Features.Requests;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Handlers;

public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, TagResponseDto>
{

    private readonly IMapper _mapper;
    private readonly ITagRepository _tagReposiotory;

    public CreateTagCommandHandler(IMapper mapper, ITagRepository tagRepository)
    {
        _mapper = mapper;
        _tagReposiotory = tagRepository;
    }
    public async Task<TagResponseDto> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        var result = await _tagReposiotory.Add(_mapper.Map<Tag>(request.CreateTagDto));

        return new TagResponseDto(){Title = result.Title};
    }
}