using AutoMapper;
using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.PostDtos;
using SocialSync.Application.Features.Posts.Requests.Queries;

namespace SocialSync.Application.Features.Posts.Handlers.Queries;

public class GetPostByIdRequestHandler : IRequestHandler<GetPostByIdRequest, CommonResponse<PostDto>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public GetPostByIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<PostDto>> Handle(GetPostByIdRequest request, CancellationToken cancellationToken)
    {
        var post = await _unitOfWork.PostRepository.GetAsync(request.Id);
        var response = CommonResponse<PostDto>.Success(_mapper.Map<PostDto>(post));
        return response;
    }
}