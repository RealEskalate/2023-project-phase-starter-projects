using AutoMapper;
using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.PostDtos;
using SocialSync.Application.Features.Posts.Requests.Queries;

namespace SocialSync.Application.Features.Posts.Handlers.Queries;

public class GetPostsByUserIdRequestHandler : IRequestHandler<GetPostsByUserIdRequest, CommonResponse<List<PostDto>>>
{
    private IPostRepository _postRepository;
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public GetPostsByUserIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _postRepository = _unitOfWork.PostRepository;
        _mapper = mapper;
    }

    public async Task<CommonResponse<List<PostDto>>> Handle(GetPostsByUserIdRequest request, CancellationToken cancellationToken)
    {
        var postsByUserId = await _unitOfWork.PostRepository.GetPostsByUserIdAsync(request.UserId);
        var response = CommonResponse<List<PostDto>>.Success(_mapper.Map<List<PostDto>>(postsByUserId));
        return response;
    }
}
