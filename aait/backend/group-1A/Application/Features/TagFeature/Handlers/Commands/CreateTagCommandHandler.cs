using Application.Response;
using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts;
using SocialSync.Application.DTO;
using SocialSync.Application.Features.Requests;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Handlers;

public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, BaseResponse<string>>
{

    private readonly IMapper _mapper;
    private readonly ITagRepository _tagReposiotory;

    public CreateTagCommandHandler(IMapper mapper, ITagRepository tagRepository)
    {
        _mapper = mapper;
        _tagReposiotory = tagRepository;
    }
    public async Task<BaseResponse<string>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        var result = await _tagReposiotory.Add(_mapper.Map<Tag>(request.CreateTagDto));

        return new BaseResponse<string>(){
            Value = result.Title
        };
    }
}