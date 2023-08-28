using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts;
using SocialSync.Application.DTO;
using SocialSync.Application.Features.Requests;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Handlers;

public class GetAllTagsRequestHandler : IRequestHandler<GetAllTagsRequest, IEnumerable<TagResponseDto>>
{
    private readonly IMapper _mapper;
    private readonly ITagRepository _tagReposiotry;
    public GetAllTagsRequestHandler(ITagRepository tagRepository,IMapper mapper)
    {
        _tagReposiotry = tagRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<TagResponseDto>> Handle(GetAllTagsRequest request, CancellationToken cancellationToken)
    {
        var tags = await _tagReposiotry.GetAll();
        Console.WriteLine(tags);
        
        return _mapper.Map<IEnumerable<TagResponseDto>>(tags);

    }
}