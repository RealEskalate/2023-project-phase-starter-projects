using AutoMapper;
using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.PostDtos;
using SocialSync.Application.Features.Posts.Requests.Queries;

namespace SocialSync.Application.Features.Posts.Handlers.Queries;


public class GetAllPostsRequestHandler : IRequestHandler<GetAllPostsRequest, CommonResponse<List<PostDto>>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public GetAllPostsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<List<PostDto>>> Handle(GetAllPostsRequest request, CancellationToken cancellationToken)
    {
        CommonResponse<List<PostDto>> response;
        response = CommonResponse<List<PostDto>>.Success(_mapper.Map<List<PostDto>>(await _unitOfWork.PostRepository.GetAsync()));
        return response;
    }
}