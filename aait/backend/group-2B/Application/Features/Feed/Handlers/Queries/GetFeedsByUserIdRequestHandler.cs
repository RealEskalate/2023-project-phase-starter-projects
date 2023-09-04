using AutoMapper;
using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.PostDtos;
using SocialSync.Application.Features.Feed.Requests.Queries;

namespace SocialSync.Application.Features.Feed.Handlers.Queries;

public class GetFeedsByUserIdRequestHandler : IRequestHandler<GetFeedsByUserIdRequest, CommonResponse<List<PostDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetFeedsByUserIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper){
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<List<PostDto>>> Handle(GetFeedsByUserIdRequest request, CancellationToken cancellationToken){
        
        var user = await _unitOfWork.UserRepository.GetAsync(request.UserID);
        if (user == null){
            return CommonResponse<List<PostDto>>.Failure("User Doesn't Exist");
        }

        var feeds = await _unitOfWork.PostRepository.GetFeedsByUserIdAsync(request.UserID);
        if(feeds == null){
            CommonResponse<List<PostDto>>.Failure("Feeds Not Found!");
        }
        
        return CommonResponse<List<PostDto>>.Success(_mapper.Map<List<PostDto>>(feeds));
    }
}