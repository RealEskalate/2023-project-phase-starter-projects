using AutoMapper;
using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.PostDtos;
using SocialSync.Application.Features.Posts.Requests.Queries;

namespace SocialSync.Application.Features.Posts.Handlers.Queries;

public class GetPostsByTagsRequestHandler : IRequestHandler<GetPostsByTagsRequest, CommonResponse<List<PostDto>>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public GetPostsByTagsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<List<PostDto>>> Handle(GetPostsByTagsRequest request, CancellationToken cancellationToken)
    {
        var postsByTags = await _unitOfWork.PostRepository.GetPostsByTagsAsync(request.Tags);
        var response = CommonResponse<List<PostDto>>.Success(_mapper.Map<List<PostDto>>(postsByTags));
        return response;
    }
}
